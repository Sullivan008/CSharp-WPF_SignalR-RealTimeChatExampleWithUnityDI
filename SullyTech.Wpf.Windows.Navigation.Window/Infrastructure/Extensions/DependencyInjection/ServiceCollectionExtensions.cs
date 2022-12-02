using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Navigation.Window.Interfaces;

namespace SullyTech.Wpf.Windows.Navigation.Window.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddNavigationWindow<TNavigationWindow>(this IServiceCollection @this)
        where TNavigationWindow : INavigationWindow
    {
        @this.AddTransient(typeof(TNavigationWindow));
    }
}