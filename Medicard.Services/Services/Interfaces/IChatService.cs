using Medicard.Domain.Entities;
using Medicard.Services.ViewModels.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Services.Services.Interfaces
{
    public interface IChatService
    {
        Task<List<ChatViewModel>> GetListChats(List<User> allUsers, User currentUser);

        Task<List<User>> GetAllTargetUsersBasedOnRole(User currentUser);

        List<Message> GetAllMessages(User currentUser, User targetUser);

        Message AddMessage(string Text, User sender);
    }
}
