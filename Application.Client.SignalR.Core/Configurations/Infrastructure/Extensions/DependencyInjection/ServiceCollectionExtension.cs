using Application.Client.SignalR.Core.Configurations.Enums;
using Application.Client.SignalR.Core.Configurations.Models;
using Application.Common.Utilities.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.SignalR.Core.Configurations.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddHubConfigurations(this IServiceCollection @this, IConfiguration configuration)
    {
        string configurationSectionKey = ConfigurationSectionKey.HubConfigurations.GetEnumMemberAttrValue();
        IConfigurationSection configurationSection = configuration.GetSection(configurationSectionKey);

        @this.Configure<HubConfigurations>(configurationSection);

        return @this;
    }
}
