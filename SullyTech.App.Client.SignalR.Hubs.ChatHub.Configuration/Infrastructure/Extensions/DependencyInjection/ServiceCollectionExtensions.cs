using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.App.Client.SignalR.Hubs.ChatHub.Configuration.Enums;
using SullyTech.App.Client.SignalR.Hubs.ChatHub.Configuration.Models;
using SullyTech.Extensions.Enum;
using SullyTech.SignalR.Client.Core.Hub.Configuration.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.App.Client.SignalR.Hubs.ChatHub.Configuration.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddChatHubConfiguration(this IServiceCollection @this, IConfiguration configuration)
    {
        string? configurationSectionKey = ConfigurationSectionKey.ChatHubConfiguration.GetEnumMemberAttrValue();
        Guard.Guard.ThrowIfNullOrWhitespace(configurationSectionKey, nameof(configurationSectionKey));

        @this.AddHubConfiguration<ChatHubConfiguration>(configuration, configurationSectionKey!);
    }
}