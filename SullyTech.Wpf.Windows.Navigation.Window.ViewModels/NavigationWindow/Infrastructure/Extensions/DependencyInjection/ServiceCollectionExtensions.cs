using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Navigation.Window.ViewModels.Interfaces.NavigationWindow;

namespace SullyTech.Wpf.Windows.Navigation.Window.ViewModels.NavigationWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddNavigationWindowViewModel<TINavigationWindowViewModel, TNavigationWindowViewModel>(this IServiceCollection @this)
        where TNavigationWindowViewModel : TINavigationWindowViewModel
        where TINavigationWindowViewModel : INavigationWindowViewModel
    {
        @this.AddTransient(typeof(TINavigationWindowViewModel), typeof(TNavigationWindowViewModel));
    }
}