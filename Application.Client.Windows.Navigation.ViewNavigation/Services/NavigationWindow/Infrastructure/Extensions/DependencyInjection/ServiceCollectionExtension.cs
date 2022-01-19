using Application.Client.Windows.Navigation.ViewNavigation.Services.NavigationWindow.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Navigation.ViewNavigation.Services.NavigationWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddNavigationWindowService(this IServiceCollection @this)
    {
        @this.AddTransient<INavigationWindowService, NavigationWindowService>();

        return @this;
    }
}