using Microsoft.AspNet.SignalR.Client;
using SignalRChatExampleClient.Enums;
using SignalRChatExampleClient.Models;
using SignalRChatExampleClient.Modules.Chat.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SignalRChatExampleClient.Modules.Chat.Services
{
    public class ChatService : IChatService
    {
        private IHubProxy _hubProxy;

        public event Action<User> ParticipantLoggedIn;
        public event Action<string> ParticipantLoggedOut;
        public event Action<string> ParticipantDisconnected;
        public event Action<string> ParticipantReconnected;
        public event Action ConnectionReconnecting;
        public event Action ConnectionReconnected;
        public event Action ConnectionClosed;
        public event Action<string, string, DateTime, MessageType> NewMessage;

        public async Task ConnectAsync()
        {
            HubConnection hubConnection = new HubConnection("http://localhost:8080/signalchat");
            _hubProxy = hubConnection.CreateHubProxy("ChatHub");

            RegisterServerSideReceivingActions();
            SubscribeToDelegates(hubConnection);

            ServicePointManager.DefaultConnectionLimit = 10;

            await hubConnection.Start();
        }

        #region SERVERSIDE SENDING Methods

        public async Task<bool> LoginAsync(string loginUserName) =>
            await _hubProxy.Invoke<bool>("Login", loginUserName);

        public async Task<List<User>> GetLoggedUsersAsync() =>
            await _hubProxy.Invoke<List<User>>("GetLoggedUsers");

        public async Task LogoutAsync() =>
            await _hubProxy.Invoke("Logout");

        public async Task SendBroadcastMessageAsync(string message, DateTime messagePostedDateTime) =>
            await _hubProxy.Invoke("BroadcastChat", message, messagePostedDateTime);

        public async Task SendUnicastMessageAsync(string recipientId, string message, DateTime messagePostedDateTime) =>
            await _hubProxy.Invoke("UnicastChat", recipientId, message, messagePostedDateTime);

        public async Task SendUnicastNotificationAsync(string recipientId, string message, DateTime messagePostedDateTime) =>
            await _hubProxy.Invoke("UnicastNotification", recipientId, message, messagePostedDateTime);

        #endregion

        #region DELEGATES

        private void Disconnected() =>
            ConnectionClosed?.Invoke();

        private void Reconnecting() =>
            ConnectionReconnecting?.Invoke();

        private void Reconnected() =>
            ConnectionReconnected?.Invoke();

        #endregion

        #region PRIVATE Helper Methods

        private void RegisterServerSideReceivingActions()
        {
            _hubProxy.On<User>("ParticipantLogin", loggedUser => ParticipantLoggedIn?.Invoke(loggedUser));
            _hubProxy.On<string>("ParticipantLogout", loggedOutUserName => ParticipantLoggedOut?.Invoke(loggedOutUserName));
            _hubProxy.On<string>("ParticipantDisconnection", disconnectionConnectionId => ParticipantDisconnected?.Invoke(disconnectionConnectionId));
            _hubProxy.On<string>("ParticipantReconnection", reconnectionConnectionId => ParticipantReconnected?.Invoke(reconnectionConnectionId));
            _hubProxy.On<string, string, DateTime>("BroadcastMessage", (senderConnectionId, message, messagePostedDateTime) => NewMessage?.Invoke(senderConnectionId, message, messagePostedDateTime, MessageType.Broadcast));
            _hubProxy.On<string, string, DateTime>("UnicastMessage", (senderConnectionId, message, messagePostedDateTime) => NewMessage?.Invoke(senderConnectionId, message, messagePostedDateTime, MessageType.Unicast));
            _hubProxy.On<string, string, DateTime>("UnicastNotification", (senderConnectionId, message, messagePostedDateTime) => NewMessage?.Invoke(senderConnectionId, message, messagePostedDateTime, MessageType.UnicastNotification));
        }

        private void SubscribeToDelegates(HubConnection hubConnection)
        {
            hubConnection.Reconnecting += Reconnecting;
            hubConnection.Reconnected += Reconnected;
            hubConnection.Closed += Disconnected;
        }

        #endregion
    }
}
