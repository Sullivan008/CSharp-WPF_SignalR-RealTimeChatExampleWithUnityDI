using App.Client.SignalR.Hubs.Chat.Configuration.Infrastructure.Extensions.DependencyInjection;
using App.Client.SignalR.Hubs.Chat.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Client.SignalR.Hubs.Chat.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static void AddChatHub(this IServiceCollection @this, IConfiguration configuration)
    {
        @this.AddChatHubConfiguration(configuration);

        @this.AddSingleton<IChatHub, ChatHub>();
    }
}