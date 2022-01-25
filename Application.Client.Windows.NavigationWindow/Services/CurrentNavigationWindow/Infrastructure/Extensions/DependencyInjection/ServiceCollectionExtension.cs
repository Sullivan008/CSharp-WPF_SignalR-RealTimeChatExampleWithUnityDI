using Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.Window.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddCurrentNavigationWindowService<TNavigationWindow>(this IServiceCollection @this) where TNavigationWindow : INavigationWindow
    {
        @this.AddTransient<Func<TNavigationWindow, ICurrentNavigationWindowService>>(serviceProvider =>
            navigationWindow => new CurrentNavigationWindowService(serviceProvider, navigationWindow));

        return @this;
    }
}