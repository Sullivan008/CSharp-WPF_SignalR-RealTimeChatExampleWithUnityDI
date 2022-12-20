using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Navigation.Window.Interfaces;

namespace SullyTech.Wpf.Windows.Navigation.Window.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddNavigationWindow<TINavigationWindow, TNavigationWindow>(this IServiceCollection @this)
        where TNavigationWindow : TINavigationWindow
        where TINavigationWindow : INavigationWindow
    {
        @this.AddTransient(typeof(TINavigationWindow), typeof(TNavigationWindow));
    }
}