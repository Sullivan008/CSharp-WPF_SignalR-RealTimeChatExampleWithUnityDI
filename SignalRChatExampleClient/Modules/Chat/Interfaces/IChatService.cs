using SignalRChatExampleClient.Enums;
using SignalRChatExampleClient.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRChatExampleClient.Modules.Chat.Interfaces
{
    public interface IChatService
    {
        #region PRIVATE Helper Methods

        event Action<User> ParticipantLoggedIn;
        event Action<string> ParticipantLoggedOut;
        event Action<string> ParticipantDisconnected;
        event Action<string> ParticipantReconnected;
        event Action ConnectionReconnecting;
        event Action ConnectionReconnected;
        event Action ConnectionClosed;
        event Action<string, string, DateTime, MessageType> NewMessage;

        #endregion

        #region SERVERSIDE SENDING Methods

        Task ConnectAsync();

        Task<bool> LoginAsync(string loginUserName);

        Task<List<User>> GetLoggedUsersAsync();

        Task LogoutAsync();

        Task SendBroadcastMessageAsync(string message, DateTime messagePostedDateTime);

        Task SendUnicastMessageAsync(string recipientId, string message, DateTime messagePostedDateTime);

        Task SendUnicastNotificationAsync(string recipientId, string message, DateTime messagePostedDateTime);

        #endregion
    }
}
