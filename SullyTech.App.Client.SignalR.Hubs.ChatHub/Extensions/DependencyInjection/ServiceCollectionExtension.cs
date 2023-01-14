using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.App.Client.SignalR.Hubs.ChatHub.Configuration.Infrastructure.Extensions.DependencyInjection;
using SullyTech.App.Client.SignalR.Hubs.ChatHub.Interfaces;

namespace SullyTech.App.Client.SignalR.Hubs.ChatHub.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static void AddChatHub(this IServiceCollection @this, IConfiguration configuration)
    {
        @this.AddChatHubConfiguration(configuration);

        @this.AddSingleton<IChatHub, ChatHub>();
    }
}