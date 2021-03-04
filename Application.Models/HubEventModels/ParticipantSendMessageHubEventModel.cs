using System;

namespace Application.Models.HubEventModels
{
    public class ParticipantSendMessageHubEventModel
    {
        public string SenderId { get; }

        public string Message { get; }

        public DateTime PostedTime { get; }

        public ParticipantSendMessageHubEventModel(string senderId, string message, DateTime postedTime)
        {
            SenderId = !string.IsNullOrWhiteSpace(senderId) ? senderId : throw new ArgumentNullException(nameof(senderId), "The value cannot be null!");
            Message = !string.IsNullOrWhiteSpace(message) ? message : throw new ArgumentNullException(nameof(message), "The value cannot be null!");

            PostedTime = postedTime;
        }
    }
}
