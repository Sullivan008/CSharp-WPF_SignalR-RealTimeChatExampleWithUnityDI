using System;

namespace Application.Models.HubEventModels
{
    public class ParticipantReconnectedHubEventModel
    {
        public string Id { get; }

        public ParticipantReconnectedHubEventModel(string id)
        {
            Id = !string.IsNullOrWhiteSpace(id) ? id : throw new ArgumentNullException(nameof(id), "The value cannot be null!");
        }
    }
}
