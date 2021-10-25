using System.Configuration;

namespace Application.Client.Core.AppConfigurations.SignalR.ConfigurationSections.ConfigurationElements
{
    public class ChatHubConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("HubName", IsRequired = true)]
        public string HubName
        {
            get => (string)this["HubName"];
            set => this["HubName"] = value;
        }

        [ConfigurationProperty("ReconnectTimeInterval", IsRequired = true)]
        public int ReconnectTimeInterval
        {
            get => (int)this["ReconnectTimeInterval"];
            set => this["ReconnectTimeInterval"] = value;
        }
    }
}
