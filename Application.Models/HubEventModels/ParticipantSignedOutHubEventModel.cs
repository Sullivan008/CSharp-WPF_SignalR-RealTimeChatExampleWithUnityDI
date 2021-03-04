using System;

namespace Application.Models.HubEventModels
{
    public class ParticipantSignedOutHubEventModel
    {
        public string Id { get; }

        public ParticipantSignedOutHubEventModel(string id)
        {
            Id = !string.IsNullOrWhiteSpace(id) ? id : throw new ArgumentNullException(nameof(id), "The value cannot be null!");
        }
    }
}
