using Application.Client.SignalR.Infrastructure.Configurations.Enums;
using Application.Client.SignalR.Infrastructure.Configurations.HubConfigurations;
using Application.Utilities.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.SignalR.Infrastructure.Extensions.DependencyInjection;

public static class SignalRServiceCollectionExtension
{
    public static IServiceCollection AddHubConfigurations(this IServiceCollection @this, IConfiguration configuration)
    {
        @this.Configure<HubConfigurations>(configuration.GetSection(ConfigurationType.HubConfigurations.GetEnumMemberAttrValue()));

        return @this;
    }
}