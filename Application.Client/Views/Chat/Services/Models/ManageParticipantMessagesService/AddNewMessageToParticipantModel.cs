using System;

namespace Application.Client.Views.Chat.Services.Models.ManageParticipantMessagesService
{
    public class AddNewMessageToParticipantModel
    {
        public string ParticipantId { get; }

        public string Message { get; }

        public DateTime PostedTime { get; }

        public bool IsOwnMessage { get; }

        public AddNewMessageToParticipantModel(string participantId, string message, DateTime postedTime, bool isOwnMessage = false)
        {
            ParticipantId = !string.IsNullOrWhiteSpace(participantId) ? participantId : throw new ArgumentNullException(nameof(participantId), @"The value cannot be null!");
            Message = !string.IsNullOrWhiteSpace(message) ? message : throw new ArgumentNullException(nameof(message), @"The value cannot be null!");

            PostedTime = postedTime;
            IsOwnMessage = isOwnMessage;
        }
    }
}
