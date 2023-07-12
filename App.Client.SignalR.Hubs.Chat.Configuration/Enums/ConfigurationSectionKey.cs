using System.Runtime.Serialization;

namespace App.Client.SignalR.Hubs.Chat.Configuration.Enums;

public enum ConfigurationSectionKey
{
    [EnumMember(Value = "CHAT_HUB_CONFIGURATION")]
    ChatHubConfiguration = 1
}