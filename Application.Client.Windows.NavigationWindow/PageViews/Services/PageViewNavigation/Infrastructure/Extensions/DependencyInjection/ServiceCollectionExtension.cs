using Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation.Interfaces;
using Application.Client.Windows.NavigationWindow.Window.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static void AddPageViewNavigationService<TNavigationWindow>(this IServiceCollection @this) where TNavigationWindow : INavigationWindow
    {
        @this.AddTransient<Func<TNavigationWindow, IPageViewNavigationService>>(serviceProvider =>
        {
            return navigationWindow => new PageViewNavigationService(serviceProvider, navigationWindow);
        });
    }
}