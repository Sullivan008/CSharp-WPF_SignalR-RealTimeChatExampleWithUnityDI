using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Application.Client.SignalR.Hubs.Chat.StaticValues.Enums;

namespace Application.Client.SignalR.Hubs.Chat.StaticValues
{
    public static class ServerMethods
    {
        private static readonly ReadOnlyDictionary<ServerMethodType, string> ServerMethodNames;

        static ServerMethods()
        {
            ServerMethodNames = new ReadOnlyDictionary<ServerMethodType, string>(new Dictionary<ServerMethodType, string>
            {
                { ServerMethodType.SignIn, ServerMethodType.SignIn.ToString() },
                { ServerMethodType.SignOut, ServerMethodType.SignOut.ToString() },
                { ServerMethodType.IsSignedIn, ServerMethodType.IsSignedIn.ToString() },
                { ServerMethodType.GetParticipants, ServerMethodType.GetParticipants.ToString() },
                { ServerMethodType.SendMessage, ServerMethodType.SendMessage.ToString() },
            });
        }

        public static string GetServerMethodName(ServerMethodType serverMethodType)
        {
            ServerMethodNames.TryGetValue(serverMethodType, out string result);

            if (result == null)
            {
                throw new ArgumentNullException(nameof(result), $@"The following Server Method does not exist with this key. {nameof(serverMethodType).ToUpper()}: {serverMethodType}");
            }

            return result;
        }
    }
}
