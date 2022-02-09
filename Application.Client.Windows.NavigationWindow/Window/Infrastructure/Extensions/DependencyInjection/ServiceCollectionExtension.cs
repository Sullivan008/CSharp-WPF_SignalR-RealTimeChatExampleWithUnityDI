using Application.Client.Windows.NavigationWindow.Window.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.NavigationWindow.Window.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static void AddNavigationWindow<TNavigationWindow>(this IServiceCollection @this)
        where TNavigationWindow : INavigationWindow
    {
        @this.AddTransient(typeof(TNavigationWindow));
    }
}