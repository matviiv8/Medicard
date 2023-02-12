namespace Medicard.Services.ViewModels.Chat
{
    public class ChatViewModel
    {
        public string Id { get; set; }

        public string Picture { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public string LastMessageText { get; set; }

        public string LastMessageSender { get; set; }

        public DateTime LastMessageDateTime { get; set; }
    }
}
