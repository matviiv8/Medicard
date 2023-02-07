using Medicard.Domain.Concrete;
using Medicard.Domain.Entities;
using Medicard.Services.Services.Interfaces;
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
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IChatService _chatService;

        public ChatController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IChatService chatService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _chatService = chatService;
        }

        public async Task<IActionResult> AllChats(string search, string userName = "")
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var targetUser = await _userManager.FindByNameAsync(userName);
            var allUsers = await _chatService.GetAllTargetUsersBasedOnRole(currentUser);

            ViewData["Search"] = search;

            if (!String.IsNullOrEmpty(search))
            {
                allUsers = allUsers
                    .Where(user => user.ToString().ToLower().Contains(search.ToLower())).ToList();
            }

            var chatsViewModel = await _chatService.GetListChats(allUsers, currentUser);

            if(!string.IsNullOrEmpty(userName))
            {
                var messages = _chatService.GetAllMessages(currentUser, targetUser);

                ViewBag.Messages = messages;
                ViewBag.CurrentUser = currentUser;
                ViewBag.TargetUser = targetUser;

                ViewBag.UserName = userName;
            }

            return View(chatsViewModel);
        }

        [HttpPost]
        public IActionResult SwitchChat(string userName)
        {
            return this.RedirectToAction("AllChats", new { userName = userName });
        }

        public async Task<IActionResult> SendMessage(string Text, [FromServices] IHubContext<ChatHub> chat)
        {
            var sender = await _userManager.GetUserAsync(User);
            var message = _chatService.AddMessage(Text, sender);

            await chat.Clients.All.SendAsync("ReceiveMessage", message);

            return Ok();
        }
    }
}
