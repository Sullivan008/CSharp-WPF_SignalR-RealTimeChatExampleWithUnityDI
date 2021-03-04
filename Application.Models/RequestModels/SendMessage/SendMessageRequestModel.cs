using System;

namespace Application.Models.RequestModels.SendMessage
{
    public class SendMessageRequestModel
    {
        public string RecipientId { get; }

        public string Message { get; }

        public DateTime PostedTime { get; }

        public SendMessageRequestModel(string recipientId, string message, DateTime postedTime)
        {
            RecipientId = !string.IsNullOrWhiteSpace(recipientId) ? recipientId : throw new ArgumentNullException(nameof(recipientId), "The value cannot be null!");
            Message = !string.IsNullOrWhiteSpace(message) ? message : throw new ArgumentNullException(nameof(message), "The value cannot be null!");
            PostedTime = postedTime;
        }
    }
}
