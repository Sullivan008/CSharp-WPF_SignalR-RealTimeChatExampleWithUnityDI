using Application.Client.SignalR.Hubs.ChatHub.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Application.Client.SignalR.Hubs.ChatHub.Extensions.Hosting;

public static class HostExtensions
{
    public static IHost ConnectToChatHub(this IHost @this)
    {
        using IServiceScope serviceScope = @this.Services.CreateScope();

        IServiceProvider serviceProvider = serviceScope.ServiceProvider;
        IChatHub chatHub = serviceProvider.GetRequiredService<IChatHub>();

        chatHub.ConnectAsync()
               .Wait();

        return @this;
    }
}