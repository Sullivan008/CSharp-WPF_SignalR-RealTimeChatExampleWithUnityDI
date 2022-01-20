using Application.Client.Windows.NavigationWindow.Services.NavigationWindow.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.NavigationWindow.Services.NavigationWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddNavigationWindowService(this IServiceCollection @this)
    {
        @this.AddTransient<INavigationWindowService, NavigationWindowService>();

        return @this;
    }
}