using Medicard.Domain.Astract;
using Medicard.Domain.Concrete;
using Medicard.Domain.Entities;
using Medicard.WebUI.Hubs;
using Medicard.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Medicard.WebUI.Controllers
{
    public class ChatController : Controller
    {
        private readonly MedicardDbContext _context;
        private readonly UserManager<User> _userManager;

        public ChatController(MedicardDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Private()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var allUsers = _context.Users.Where(u => u.UserName != currentUser.UserName).ToList();
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
