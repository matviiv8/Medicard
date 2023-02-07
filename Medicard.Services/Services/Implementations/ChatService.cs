using Medicard.Domain.Astract;
using Medicard.Domain.Concrete;
using Medicard.Domain.Entities;
using Medicard.Services.Services.Interfaces;
using Medicard.Services.ViewModels.Chat;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Services.Services.Implementations
{
    public class ChatService : IChatService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public ChatService(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            this._unitOfWork = unitOfWork;
            this._userManager = userManager;
        }

        public async Task<List<ChatViewModel>> GetListChats(List<User> allUsers, User currentUser)
        {
            var chatsViewModel = new List<ChatViewModel>();

            foreach (var targetUser in allUsers)
            {
                var chat = new ChatViewModel
                {
                    UserName = targetUser.UserName,
                    FullName = targetUser.ToString(),
                };

                var picture = await GetPictureForChat(targetUser);

                if (picture == null)
                {
                    var doctor = _unitOfWork.GenericRepository<Doctor>().GetAll().Where(doctor => doctor.UserId == targetUser.Id).FirstOrDefault();
                    chat.Picture = doctor.DoctorPicture;
                }
                else
                {
                    chat.Picture = picture;
                }

                var lastMessage = GetLastMessage(currentUser, targetUser);

                if (lastMessage != null)
                {
                    var sender = await _userManager.FindByNameAsync(lastMessage.UserName);
                    chat.LastMessageText = lastMessage.Text;
                    chat.LastMessageDateTime = lastMessage.When;
                    chat.LastMessageSender = sender.ToString();
                }

                chatsViewModel.Add(chat);
            }

            return chatsViewModel;
        }

        public async Task<List<User>> GetAllTargetUsersBasedOnRole(User currentUser)
        {
            var isCurrentRoleDoctor = await _userManager.IsInRoleAsync(currentUser, "Doctor");
            var isCurrentRoleHeadDoctor = await _userManager.IsInRoleAsync(currentUser, "Head doctor");
            var isCurrentRoleAdmin = await _userManager.IsInRoleAsync(currentUser, "Admin");
            var allUsers = _unitOfWork.GenericRepository<User>().GetAll();
            var allTargetUsersBasedOnRole = new List<User>();

            if (isCurrentRoleDoctor || isCurrentRoleAdmin || isCurrentRoleHeadDoctor)
            {
                allTargetUsersBasedOnRole = _unitOfWork.GenericRepository<User>().GetAll().Where(user => user.UserName != currentUser.UserName).ToList();
            }
            else
            {
                var allDoctors = _unitOfWork.GenericRepository<Doctor>().GetAll();
                foreach (var doctor in allDoctors)
                {
                    allTargetUsersBasedOnRole.Add(allUsers.Where(user => user.UserName != currentUser.UserName && user.Id == doctor.UserId).First());
                }
            }

            return allTargetUsersBasedOnRole;
        }

        public List<Message> GetAllMessages(User currentUser, User targetUser)
        {
            return _unitOfWork.GenericRepository<Message>()
                .GetAll(message => (message.UserName == currentUser.UserName && message.TargetName == targetUser.UserName) ||
                (message.UserName == targetUser.UserName && message.TargetName == currentUser.UserName))
                .ToList();
        }

        public Message AddMessage(string Text, User sender)
        {
            Message message = new Message
            {
                Text = Text,
                UserName = sender.UserName,
                UserId = sender.Id,
                When = DateTime.Now,
            };

            _unitOfWork.GenericRepository<Message>().Add(message);
            _unitOfWork.Save();

            return message;
        }

        private Message GetLastMessage(User currentUser, User targetUser)
        {
            return _unitOfWork.GenericRepository<Message>()
                .GetAll(message => (message.TargetId == targetUser.Id && message.UserId == currentUser.Id) || (message.UserId == targetUser.Id && message.TargetId == currentUser.Id))
                .OrderByDescending(message => message.When)
                .FirstOrDefault();
        }

        private async Task<string> GetPictureForChat(User user)
        {
            return await _userManager.IsInRoleAsync(user, "Admin") ? "admin-icon.png" :
               await _userManager.IsInRoleAsync(user, "Doctor") || await _userManager.IsInRoleAsync(user, "Head doctor") ? null : "user-icon.png";
        }
    }
}
