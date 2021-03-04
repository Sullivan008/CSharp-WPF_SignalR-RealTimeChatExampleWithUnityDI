using System.Configuration;

namespace Application.Client.Core.AppConfigurations.SignalR.ConfigurationSections.ConfigurationElements
{
    public class HubConnectionConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("Url", IsRequired = true)]
        public string Url
        {
            get => (string)this["Url"];
            set => this["Url"] = value;
        }
    }
}
