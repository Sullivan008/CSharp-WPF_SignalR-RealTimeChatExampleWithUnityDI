using App.Core.Extensions.Implementation.Enum;
using App.Core.Guard.Implementation;
using Application.Client.SignalR.Core.Configurations.Enums;
using Application.Client.SignalR.Core.Configurations.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.SignalR.Core.Configurations.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddHubConfigurations(this IServiceCollection @this, IConfiguration configuration)
    {
        string? configurationSectionKey = ConfigurationSectionKey.HubConfigurations.GetEnumMemberAttrValue();
        Guard.ThrowIfNullOrWhitespace(configurationSectionKey, nameof(configurationSectionKey));

        IConfigurationSection configurationSection = configuration.GetRequiredSection(configurationSectionKey);

        @this.Configure<HubConfigurations>(configurationSection);

        return @this;
    }
}
