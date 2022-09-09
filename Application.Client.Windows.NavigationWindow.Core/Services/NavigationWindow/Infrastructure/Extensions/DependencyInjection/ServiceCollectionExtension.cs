using Application.Client.Windows.NavigationWindow.Core.Services.NavigationWindow.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.NavigationWindow.Core.Services.NavigationWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddNavigationWindowService(this IServiceCollection @this)
    {
        @this.AddTransient<INavigationWindowService, NavigationWindowService>();

        return @this;
    }
}