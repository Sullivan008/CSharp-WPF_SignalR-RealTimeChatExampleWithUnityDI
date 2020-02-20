using System;

namespace SignalRChatExampleClient.Models
{
    public class ChatMessage
    {
        public string SenderName { get; set; }

        public DateTime MessagePostedDateTime { get; set; }

        public bool IsSenderMessage { get; set; }

        public string Message { get; set; }
    }
}
