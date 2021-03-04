using System;

namespace Application.Client.Views.Chat.Services.Models.ManageParticipantMessagesService
{
    public class RemoveSignedOutParticipantMessagesModel
    {
        public string ParticipantId { get; }

        public RemoveSignedOutParticipantMessagesModel(string participantId)
        {
            ParticipantId = !string.IsNullOrWhiteSpace(participantId) ? participantId : throw new ArgumentNullException(nameof(participantId), @"The value cannot be null!");
        }
    }
}
