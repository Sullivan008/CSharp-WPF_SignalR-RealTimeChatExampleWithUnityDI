using System.Configuration;
using Application.Server.Core.AppConfigurations.Hosting.ConfigurationSections.ConfigurationElements;

namespace Application.Server.Core.AppConfigurations.Hosting.ConfigurationSections
{
    public class HostingConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("HostConfiguration")]
        public HostConfigurationElement HostConfigurationElement => (HostConfigurationElement)this["HostConfiguration"];
    }
}
