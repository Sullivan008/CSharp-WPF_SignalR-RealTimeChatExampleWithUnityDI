using System;

namespace Application.Models.HubEventModels
{
    public class ParticipantDisconnectedHubEventModel
    {
        public string Id { get; }

        public ParticipantDisconnectedHubEventModel(string id)
        {
            Id = !string.IsNullOrWhiteSpace(id) ? id : throw new ArgumentNullException(nameof(id), "The value cannot be null!");
        }
    }
}
