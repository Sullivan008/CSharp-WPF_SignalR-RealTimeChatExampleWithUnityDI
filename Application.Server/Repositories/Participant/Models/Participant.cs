using System;

namespace Application.Server.Repositories.Participant.Models
{
    public class Participant
    {
        public string Id { get; }

        public string Name { get; }

        public Participant(string id, string userName)
        {
            Id = !string.IsNullOrWhiteSpace(id) ? id : throw new ArgumentNullException(nameof(id), @"The value cannot be null!");
            Name = !string.IsNullOrWhiteSpace(userName) ? userName : throw new ArgumentNullException(nameof(userName), @"The value cannot be null!");
        }
    }
}
