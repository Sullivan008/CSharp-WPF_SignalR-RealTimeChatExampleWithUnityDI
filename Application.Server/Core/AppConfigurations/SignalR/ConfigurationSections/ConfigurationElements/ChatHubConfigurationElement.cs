using System.Configuration;

namespace Application.Server.Core.AppConfigurations.SignalR.ConfigurationSections.ConfigurationElements
{
    public class ChatHubConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("Endpoint", IsRequired = true)]
        public string Endpoint
        {
            get => (string)this["Endpoint"];
            set => this["Endpoint"] = value;
        }
    }
}
