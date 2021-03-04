using System;

namespace Application.Models.ResponseModels.GetParticipants
{
    public class ParticipantListItemResponseModel
    {
        public string Id { get; }

        public string Name { get; }

        public ParticipantListItemResponseModel(string id, string name)
        {
            Id = !string.IsNullOrWhiteSpace(id) ? id : throw new ArgumentNullException(nameof(id), "The value cannot be null!");
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name), "The value cannot be null!");
        }
    }
}
