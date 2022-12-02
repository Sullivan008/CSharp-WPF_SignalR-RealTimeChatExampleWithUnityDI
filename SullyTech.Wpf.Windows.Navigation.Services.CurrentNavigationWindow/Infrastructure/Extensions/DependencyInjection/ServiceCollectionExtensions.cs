using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Navigation.Services.CurrentNavigationWindow.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Window.Interfaces;

namespace SullyTech.Wpf.Windows.Navigation.Services.CurrentNavigationWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddCurrentNavigationWindowService<TNavigationWindow>(this IServiceCollection @this) 
        where TNavigationWindow : INavigationWindow
    {
        @this.AddTransient<Func<TNavigationWindow, ICurrentNavigationWindowService>>(serviceProvider =>
            navigationWindow => new CurrentNavigationWindowService(navigationWindow, serviceProvider));
    }
}