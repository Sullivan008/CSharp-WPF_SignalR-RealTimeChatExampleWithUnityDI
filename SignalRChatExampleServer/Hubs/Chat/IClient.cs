using SignalRChatExampleServer.Models;
using System;

namespace SignalRChatExampleServer.Hubs.Chat
{
    public interface IClient
    {
        void ParticipantLogin(User loggedUser);

        void ParticipantLogout(string loggedOutUserName);

        void ParticipantDisconnection(string disconnectionConnectionId);

        void ParticipantReconnection(string reconnectionConnectionId);

        void BroadcastMessage(string senderConnectionId, string message, DateTime messagePostedDateTime);

        void UnicastMessage(string senderConnectionId, string message, DateTime messagePostedDateTime);

        void UnicastNotification(string senderConnectionId, string message, DateTime messagePostedDateTime);
    }
}
