using System.Runtime.Serialization;

namespace Application.Client.SignalR.Infrastructure.Configurations.Enums
{
    public enum ConfigurationType
    {
        [EnumMember(Value = "HUB_CONFIGURATIONS")]
        HubConfigurations = 1
    }
}
