using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.Abstractions.Window;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static void AddViewNavigationService<TNavigationWindow>(this IServiceCollection @this) where TNavigationWindow : NavigationWindow
    {
        @this.AddTransient<Func<TNavigationWindow, IViewNavigationService>>(serviceProvider =>
        {
            return navigationWindow => new ViewNavigationService(serviceProvider, navigationWindow);
        });
    }
}