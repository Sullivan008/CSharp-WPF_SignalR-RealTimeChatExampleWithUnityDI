using Application.Client.Windows.NavigationWindow.Core.Window.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.NavigationWindow.Core.Window.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddNavigationWindow<TNavigationWindow>(this IServiceCollection @this)
        where TNavigationWindow : INavigationWindow
    {
        @this.AddTransient(typeof(TNavigationWindow));

        return @this;
    }
}