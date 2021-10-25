using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Application.Client.SignalR.Hubs.Chat.StaticValues.Enums;

namespace Application.Client.SignalR.Hubs.Chat.StaticValues
{
    public static class HubEventActions
    {
        private static readonly ReadOnlyDictionary<HubEventActionType, string> HubEventActionNames;

        static HubEventActions()
        {
            HubEventActionNames = new ReadOnlyDictionary<HubEventActionType, string>(new Dictionary<HubEventActionType, string>
            {
                { HubEventActionType.ParticipantSignedIn, HubEventActionType.ParticipantSignedIn.ToString() },
                { HubEventActionType.ParticipantSignedOut, HubEventActionType.ParticipantSignedOut.ToString() },
                { HubEventActionType.ParticipantSendMessage, HubEventActionType.ParticipantSendMessage.ToString() },
                { HubEventActionType.ParticipantDisconnected, HubEventActionType.ParticipantDisconnected.ToString() },
                { HubEventActionType.ParticipantReconnected, HubEventActionType.ParticipantReconnected.ToString() },
            });
        }

        public static string GetHubEventActionName(HubEventActionType hubEventAction)
        {
            HubEventActionNames.TryGetValue(hubEventAction, out string result);

            if (result == null)
            {
                throw new ArgumentNullException(nameof(result), $@"The following Hub Event Action does not exist with this key. {nameof(hubEventAction).ToUpper()}: {hubEventAction}");
            }

            return result;
        }
    }
}
