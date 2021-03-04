using System.Collections.Generic;

namespace Application.Server.Repositories.Participant.Interfaces
{
    public interface IParticipantRepository
    {
        void AddParticipant(Models.Participant participant);

        void RemoveParticipant(string id);

        Models.Participant GetParticipant(string id);

        IEnumerable<Models.Participant> GetParticipants();

        bool IsExistingParticipantById(string id);

        bool IsExistingParticipantByName(string name);
    }
}
