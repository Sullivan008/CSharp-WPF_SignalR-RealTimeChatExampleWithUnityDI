using System.Runtime.Serialization;

namespace Application.Client.SignalR.Configurations.Enums;

public enum ConfigurationSectionKey
{
    [EnumMember(Value = "HUB_CONFIGURATIONS")]
    HubConfigurations = 1
}