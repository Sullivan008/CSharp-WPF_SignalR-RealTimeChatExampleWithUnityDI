using System.Configuration;

namespace Application.Server.Core.AppConfigurations.Hosting.ConfigurationSections.ConfigurationElements
{
    public class HostConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("Url", IsRequired = true)]
        public string Url
        {
            get => (string)this["Url"];
            set => this["Url"] = value;
        }
    }
}
