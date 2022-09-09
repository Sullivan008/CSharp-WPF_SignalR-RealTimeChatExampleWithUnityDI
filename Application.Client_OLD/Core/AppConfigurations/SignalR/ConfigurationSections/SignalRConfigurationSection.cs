using System.Configuration;
using Application.Client.Core.AppConfigurations.SignalR.ConfigurationSections.ConfigurationElements;

namespace Application.Client.Core.AppConfigurations.SignalR.ConfigurationSections
{
    public class SignalRConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("ChatHubConfiguration")]
        public ChatHubConfigurationElement ChatHubConfigurationElement => (ChatHubConfigurationElement)this["ChatHubConfiguration"];

        [ConfigurationProperty("HubConnectionConfiguration")]
        public HubConnectionConfigurationElement HubConnectionConfiguration => (HubConnectionConfigurationElement)this["HubConnectionConfiguration"];
    }
}
