using Application.Client.SignalR.Hubs.ChatHub.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.SignalR.Hubs.ChatHub.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddChatHub(this IServiceCollection @this)
    {
        @this.AddSingleton<IChatHub, ChatHub>();

        return @this;
    }
}