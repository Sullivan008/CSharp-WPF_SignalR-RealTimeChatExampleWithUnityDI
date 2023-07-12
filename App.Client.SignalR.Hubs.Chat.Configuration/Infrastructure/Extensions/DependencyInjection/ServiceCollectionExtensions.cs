using App.Client.SignalR.Hubs.Chat.Configuration.Enums;
using App.Client.SignalR.Hubs.Chat.Configuration.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.Extensions.Enum;
using SullyTech.SignalR.Client.Core.Hub.Configuration.Infrastructure.Extensions.DependencyInjection;

namespace App.Client.SignalR.Hubs.Chat.Configuration.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddChatHubConfiguration(this IServiceCollection @this, IConfiguration configuration)
    {
        string? configurationSectionKey = ConfigurationSectionKey.ChatHubConfiguration.GetEnumMemberAttrValue();
        SullyTech.Guard.Guard.ThrowIfNullOrWhitespace(configurationSectionKey, nameof(configurationSectionKey));

        @this.AddHubConfiguration<ChatHubConfiguration>(configuration, configurationSectionKey!);
    }
}