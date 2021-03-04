using System.Configuration;
using Application.Server.Core.AppConfigurations.SignalR.ConfigurationSections.ConfigurationElements;

namespace Application.Server.Core.AppConfigurations.SignalR.ConfigurationSections
{
    public class SignalRConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("ChatHubConfiguration")]
        public ChatHubConfigurationElement ChatHubConfigurationElement => (ChatHubConfigurationElement)this["ChatHubConfiguration"];
    }
}
