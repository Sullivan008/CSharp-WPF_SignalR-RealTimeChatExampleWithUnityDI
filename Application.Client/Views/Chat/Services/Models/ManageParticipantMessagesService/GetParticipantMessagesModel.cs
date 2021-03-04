using System;

namespace Application.Client.Views.Chat.Services.Models.ManageParticipantMessagesService
{
    public class GetParticipantMessagesModel
    {
        public string ParticipantId { get; }

        public GetParticipantMessagesModel(string participantId)
        {
            ParticipantId = !string.IsNullOrWhiteSpace(participantId) ? participantId : throw new ArgumentNullException(nameof(participantId), @"The value cannot be null!");
        }
    }
}
