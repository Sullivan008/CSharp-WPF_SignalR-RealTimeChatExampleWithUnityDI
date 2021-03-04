using System;
using System.Configuration;
using Application.Server.Container.Unity;
using Application.Server.Core.AppConfigurations.SignalR.ConfigurationSections;
using Application.Server.Core.AppConfigurations.SignalR.ConfigurationSections.ConfigurationElements;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Owin;

namespace Application.Server.Hosting
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            GlobalHost.DependencyResolver.Register(typeof(IHubActivator), DependencyInjector.Retrieve<IHubActivator>);

            appBuilder.Map(ChatHubEndpoint, map =>
            {
                map.MapSignalR();
            });
        }

        private static string ChatHubEndpoint
        {
            get
            {
                SignalRConfigurationSection configurationSection = ConfigurationManager.GetSection("SignalRConfiguration") as SignalRConfigurationSection;

                if (configurationSection == null)
                {
                    throw new ArgumentNullException(nameof(configurationSection), @"The value cannot be null!");
                }

                ChatHubConfigurationElement configurationElement = configurationSection.ChatHubConfigurationElement;

                if (configurationElement == null)
                {
                    throw new ArgumentNullException(nameof(configurationElement), @"The value cannot be null!");
                }

                return configurationElement.Endpoint;
            }
        }
    }
}
