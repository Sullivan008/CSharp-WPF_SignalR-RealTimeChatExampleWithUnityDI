using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation;
using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.Abstractions.Window;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Navigation.ViewNavigation.Services.Infrastructure.Extensions.DependencyInjection;

public static class ViewNavigationServiceCollectionExtension
{
    public static void AddViewNavigationService<TNavigationWindow>(this IServiceCollection @this) where TNavigationWindow : NavigationWindow
    {
        @this.AddTransient<Func<TNavigationWindow, IViewNavigationService>>(serviceProvider =>
        {
            return navigationWindow => new ViewNavigationService(serviceProvider, navigationWindow);
        });
    }
}