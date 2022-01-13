using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.Services;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.Infrastructure.Extensions.DependencyInjection;

public static class NavigationWindowServicesServiceCollectionExtension
{
    public static IServiceCollection AddNavigationWindowService(this IServiceCollection @this)
    {
        @this.AddTransient<INavigationWindowService, NavigationWindowService>();

        return @this;
    }
}