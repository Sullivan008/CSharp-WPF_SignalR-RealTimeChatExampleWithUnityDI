using System;
using System.Configuration;
using Application.Server.Container;
using Application.Server.Core.AppConfigurations.Hosting.ConfigurationSections;
using Application.Server.Core.AppConfigurations.Hosting.ConfigurationSections.ConfigurationElements;
using Application.Server.Hosting;
using Microsoft.Owin.Hosting;

namespace Application.Server
{
    public class Server
    {
        private static void Main(string[] args)
        {
            using (WebApp.Start<Startup>(HostUrl))
            {
                log4net.Config.XmlConfigurator.Configure();

                Bootstrapper.Init();

                Console.Write($"The server is running at the following address: {HostUrl}\n\n");
                Console.ReadLine();
            }
        }

        private static string HostUrl
        {
            get
            {
                HostingConfigurationSection configurationSection = ConfigurationManager.GetSection("HostingConfiguration") as HostingConfigurationSection;

                if (configurationSection == null)
                {
                    throw new ArgumentNullException(nameof(configurationSection), @"The value cannot be null!");
                }

                HostConfigurationElement configurationElement = configurationSection.HostConfigurationElement;

                if (configurationElement == null)
                {
                    throw new ArgumentNullException(nameof(configurationElement), @"The value cannot be null!");
                }

                return configurationElement.Url;
            }
        }
    }
}
