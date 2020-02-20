using Microsoft.AspNet.SignalR;
using SignalRChatExampleServer.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChatExampleServer.Hubs.Chat
{
    public class ChatHub : Hub<IClient>
    {
        private static readonly ConcurrentDictionary<string, User> Connections =
            new ConcurrentDictionary<string, User>();


        public bool Login(string loginUserName)
        {
            if (!ConnectionsDictionaryIsContainUser(loginUserName))
            {
                User loginUser = new User
                {
                    ConnectionId = Context.ConnectionId,
                    UserName = loginUserName
                };

                if (Connections.Values.FirstOrDefault(x => x.UserName == loginUserName) != null)
                {
                    return false;
                }

                if (!Connections.TryAdd(loginUser.ConnectionId, loginUser))
                {
                    return false;
                }

                Console.WriteLine($"+++++ {loginUser.UserName} is logged on to the server!");

                Clients.CallerState.UserName = loginUser.UserName;
                Clients.Others.ParticipantLogin(loginUser);

                return true;
            }

            Console.WriteLine($"+++++ {loginUserName} is already exist in user dictionary! Caller Method: {nameof(Login)}");

            return false;
        }

        public List<User> GetLoggedUsers()
        {
            return new List<User>(Connections.Values);
        }

        public void Logout()
        {
            string loggedOutUserName = Clients.CallerState.UserName;

            if (!string.IsNullOrEmpty(loggedOutUserName))
            {
                Connections.TryRemove(Context.ConnectionId, out _);

                Clients.Others.ParticipantLogout(loggedOutUserName);

                Console.WriteLine($"----- {loggedOutUserName} logged out of the server!");
            }
            else
            {
                Console.WriteLine($"----- Caller state username cannot be specified in {nameof(Logout)} method! Caller Method: {nameof(Logout)}");
            }
        }

        public void BroadcastChat(string message, DateTime messagePostedDateTime)
        {
            if (!string.IsNullOrEmpty(message))
            {
                Clients.Others.BroadcastMessage(Context.ConnectionId, message, messagePostedDateTime);
            }
            else
            {
                Console.WriteLine($"----- Caller state username cannot be specified or message is empty in {nameof(BroadcastChat)} method!" +
                                  $" Caller Method: {nameof(BroadcastChat)}");
            }
        }

        public void UnicastChat(string recipientId, string message, DateTime messagePostedDateTime)
        {
            if (!string.IsNullOrEmpty(message) &&
                recipientId != Clients.CallerState.UserName &&
                ConnectionsDictionaryIsContainUser(recipientId))
            {
                Connections.TryGetValue(recipientId, out User recipientUser);

                if (recipientUser != null)
                {
                    Clients.Client(recipientUser.ConnectionId).UnicastMessage(Context.ConnectionId, message, messagePostedDateTime);
                }
                else
                {
                    Console.WriteLine($"----- Recipient user cannot be specified in {nameof(UnicastChat)} method! Caller Method: {nameof(UnicastChat)}");
                }
            }
            else
            {
                Console.WriteLine($"----- Caller state username cannot be specified or message is empty or recipient not found" +
                                  $" in {nameof(BroadcastChat)} method! Caller Method: {nameof(BroadcastChat)}");
            }
        }

        public void UnicastNotification(string recipientId, string message, DateTime messagePostedDateTime)
        {
            if (!string.IsNullOrEmpty(message) &&
                recipientId != Clients.CallerState.UserName &&
                ConnectionsDictionaryIsContainUser(recipientId))
            {
                Connections.TryGetValue(recipientId, out User recipientUser);

                if (recipientUser != null)
                {
                    Clients.Client(recipientUser.ConnectionId).UnicastNotification(Context.ConnectionId, message, messagePostedDateTime);
                }
                else
                {
                    Console.WriteLine($"----- Recipient user cannot be specified in {nameof(UnicastNotification)} method!" +
                                      $" Caller Method: {nameof(UnicastNotification)}");
                }
            }
            else
            {
                Console.WriteLine("----- Caller state username cannot be specified or message is empty or recipient not found" +
                                  $" in {nameof(UnicastNotification)} method! Caller Method: {nameof(UnicastNotification)}");
            }
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            KeyValuePair<string, User> connection = GetCallerConnectionFromConnections();

            if (!connection.Equals(default(KeyValuePair<string, User>)))
            {
                Clients.Others.ParticipantDisconnection(connection.Key);

                Console.WriteLine($"<> {connection.Value.UserName} disconnected from the server! ConnectionId: {connection.Key}");
            }
            else
            {
                Console.WriteLine("----- Caller state user not found in the users list" +
                                  $" in {nameof(OnDisconnected)} method! Caller Method: {nameof(OnDisconnected)}");
            }

            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            KeyValuePair<string, User> connection = GetCallerConnectionFromConnections();

            if (!connection.Equals(default(KeyValuePair<string, User>)))
            {
                Clients.Others.ParticipantReconnection(connection.Key);

                Console.WriteLine($"== {connection.Value.UserName} reconnected to server! ConnectionId: {connection.Key}");
            }
            else
            {
                Console.WriteLine("----- Caller state user not found in the users list" +
                                  $" in {nameof(OnReconnected)} method! Caller Method: {nameof(OnReconnected)}");
            }

            return base.OnReconnected();
        }

        #region PRIVATE Helper Methods

        private bool ConnectionsDictionaryIsContainUser(string userName) =>
            Connections.ContainsKey(userName);

        private KeyValuePair<string, User> GetCallerConnectionFromConnections() =>
            Connections.SingleOrDefault(x => x.Key == Context.ConnectionId);

        #endregion
    }
}
