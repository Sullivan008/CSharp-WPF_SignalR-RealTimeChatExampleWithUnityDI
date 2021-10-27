using System.Collections.Generic;

namespace Application.Web.Hub.Chat.Stores.Participant.Interfaces
{
    public interface IParticipantStore
    {
        public Models.Participant GetParticipant(string nickName);

        public Models.Participant GetParticipantByConnectionId(string connectionId);

        public IReadOnlyCollection<Models.Participant> GetParticipants();

        public void AddParticipant(Models.Participant participant);

        public void RemoveParticipant(string nickName);

        public void RefreshParticipantConnectionId(string nickName, string connectionId);
    }
}
