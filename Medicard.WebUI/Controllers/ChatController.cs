using Medicard.Domain.Concrete;
using Medicard.Domain.Entities;
using Medicard.WebUI.Hubs;
using Medicard.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Medicard.WebUI.Controllers
{
    public class ChatController : Controller
    {
        private readonly MedicardDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ChatController(MedicardDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Private()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var isCurrentRoleDoctor = await _userManager.IsInRoleAsync(currentUser, "Doctor");
            var isCurrentRoleHeadDoctor = await _userManager.IsInRoleAsync(currentUser, "Head doctor");
            var isCurrentRoleAdmin = await _userManager.IsInRoleAsync(currentUser, "Admin");
            var allUsers = new List<User>();

            if (isCurrentRoleDoctor || isCurrentRoleAdmin || isCurrentRoleHeadDoctor)
            {
                allUsers = _context.Users.Where(u => u.UserName != currentUser.UserName).ToList();
            }
            else
            {
                var allDoctors = _context.Doctors.ToList();
                foreach (var doctor in allDoctors)
                {
                    allUsers.Add(_context.Users.Where(u => u.UserName != currentUser.UserName && u.Id == doctor.UserId).First());
                }
            }

            return View(allUsers);
        }

        public async Task<IActionResult> PrivateMessage(string user)
        {
            var current = await _userManager.GetUserAsync(User);
            var target = await _userManager.FindByNameAsync(user);

            var sentMessages = _context.Messages.Where(m => m.UserName == current.UserName && m.TargetName == target.UserName).ToList();
            var receivedMessages = _context.Messages.Where(m => m.UserName == target.UserName && m.TargetName == current.UserName).ToList();
            var messages = sentMessages.Concat(receivedMessages).ToList();

            ViewBag.Messages = messages;
            ViewBag.CurrentUser = current;
            ViewBag.TargetUser = target;
            return View();
        }

        public async Task<IActionResult> SendMessage(string Text, [FromServices] IHubContext<ChatHub> chat)
        {
            var sender = await _userManager.GetUserAsync(User);
            Message message = new Message
            {
                Text = Text,
                UserName = User.Identity.Name,
                UserId = sender.Id,
                When = DateTime.Now
            };

            _context.Messages.Add(message);
            _context.SaveChanges();

            await chat.Clients.All.SendAsync("ReceiveMessage", message);

            return Ok();
        }
    }
}
