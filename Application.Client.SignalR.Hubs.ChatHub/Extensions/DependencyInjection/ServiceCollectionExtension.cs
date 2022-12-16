using Application.Client.SignalR.Hubs.ChatHub.Configuration.Infrastructure.Extensions.DependencyInjection;
using Application.Client.SignalR.Hubs.ChatHub.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.SignalR.Hubs.ChatHub.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddChatHub(this IServiceCollection @this, IConfiguration configuration)
    {
        @this.AddChatHubConfiguration(configuration);

        @this.AddSingleton<IChatHub, ChatHub>();

        return @this;
    }
}