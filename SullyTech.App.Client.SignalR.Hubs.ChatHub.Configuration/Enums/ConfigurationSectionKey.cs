using System.Runtime.Serialization;

namespace SullyTech.App.Client.SignalR.Hubs.ChatHub.Configuration.Enums;

public enum ConfigurationSectionKey
{
    [EnumMember(Value = "CHAT_HUB_CONFIGURATION")]
    ChatHubConfiguration = 1
}