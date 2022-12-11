using Medicard.Domain.Concrete;
using Medicard.Domain.Entities;
using Microsoft.AspNetCore.SignalR;

namespace Medicard.WebUI.Hubs
{
    public class ChatHub : Hub
    {
        private readonly MedicardDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ChatHub(MedicardDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task SendMessage(Message m)
        {
            m.When = DateTime.Now;

            if (m.UserName != Context.User.Identity.Name) return;
            var user = _context.Users.FirstOrDefault(u => u.UserName == m.UserName);

            if (user == null) return;

            m.UserId = user.Id;
            _context.Messages.Add(m);
            _context.SaveChanges();

            Message returnMessage = new Message
            {
                UserName = m.UserName,
                Text = m.Text,
                When = m.When
            };
            await Clients.All.SendAsync("ReceiveMessage", returnMessage);
        }

        public async Task SendPrivateMessage(Message m)
        {
            if (m.UserName != Context.User.Identity.Name) return;
            var user = _context.Users.FirstOrDefault(u => u.UserName == m.UserName);
            var target = _context.Users.FirstOrDefault(u => u.UserName == m.TargetName);

            if (target == null) return;

            m.UserId = user.Id;
            m.TargetId = target.Id;
            m.When = DateTime.Now;
            _context.Messages.Add(m);
            _context.SaveChanges();

            Message returnMessage = new Message
            {
                UserName = m.UserName,
                Text = m.Text,
                When = m.When
            };

            var currentName = Context.User.Identity.Name;
            var targetName = m.TargetName;

            var group = String.Compare(currentName.ToUpper(), targetName.ToUpper()) > 0 ? $"{targetName}{currentName}" : $"{currentName}{targetName}";
            await Clients.Group(group).SendAsync("PrivateMessage", returnMessage);
        }

        public string GetConnectionId() => Context.ConnectionId;

        public Task JoinPrivate(string targetName)
        {
            var currentName = Context.User.Identity.Name;
            var group = String.Compare(currentName.ToUpper(), targetName.ToUpper()) > 0 ? $"{targetName}{currentName}" : $"{currentName}{targetName}";
            return Groups.AddToGroupAsync(Context.ConnectionId, group);
        }

        public Task LeavePrivate(string targetName)
        {
            var currentName = Context.User.Identity.Name;
            var group = String.Compare(currentName.ToUpper(), targetName.ToUpper()) > 0 ? $"{targetName}{currentName}" : $"{currentName}{targetName}";
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, group);
        }
    }
}
