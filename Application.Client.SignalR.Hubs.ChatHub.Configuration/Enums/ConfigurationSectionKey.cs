using System.Runtime.Serialization;

namespace Application.Client.SignalR.Hubs.ChatHub.Configuration.Enums;

public enum ConfigurationSectionKey
{
    [EnumMember(Value = "CHAT_HUB_CONFIGURATION")]
    ChatHubConfiguration = 1
}