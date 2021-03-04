using Application.Models.HubEventModels;

namespace Application.Server.SignalR.Hubs.Chat.Interfaces
{
    public interface IChatHub
    {
        void ParticipantSignedIn(ParticipantSignedInHubEventModel model);

        void ParticipantSignedOut(ParticipantSignedOutHubEventModel model);

        void ParticipantSendMessage(ParticipantSendMessageHubEventModel model);

        void ParticipantDisconnected(ParticipantDisconnectedHubEventModel model);

        void ParticipantReconnected(ParticipantReconnectedHubEventModel model);
    }
}
