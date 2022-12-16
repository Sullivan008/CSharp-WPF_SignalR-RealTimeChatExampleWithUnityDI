using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.SignalR.Client.Core.Hub.Configuration.Models.Interfaces;

namespace SullyTech.SignalR.Client.Core.Hub.Configuration.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddHubConfiguration<THubConfiguration>(this IServiceCollection @this, IConfiguration configuration, string configurationSectionKey)
        where THubConfiguration : class, IHubConfiguration
    {
        Guard.Guard.ThrowIfNullOrWhitespace(configurationSectionKey, nameof(configurationSectionKey));

        IConfigurationSection configurationSection = configuration.GetRequiredSection(configurationSectionKey);

        @this.Configure<THubConfiguration>(configurationSection);
    }
}
