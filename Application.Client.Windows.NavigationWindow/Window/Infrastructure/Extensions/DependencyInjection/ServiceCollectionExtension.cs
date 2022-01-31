using Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.Window.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.NavigationWindow.Window.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static void AddNavigationWindow<TNavigationWindow, TNavigationWindowViewModel>(this IServiceCollection @this) where TNavigationWindow : INavigationWindow
                                                                                                                         where TNavigationWindowViewModel : INavigationWindowViewModel
    {
        @this.AddTransient(typeof(TNavigationWindow), serviceProvider =>
        {
            TNavigationWindow navigationWindow = Activator.CreateInstance<TNavigationWindow>();

            Func<TNavigationWindow, ICurrentNavigationWindowService> currentNavigationWindowServiceFactory = 
                serviceProvider.GetRequiredService<Func<TNavigationWindow, ICurrentNavigationWindowService>>();
            
            ICurrentNavigationWindowService currentNavigationWindowService = currentNavigationWindowServiceFactory(navigationWindow);
            
            INavigationWindowViewModel navigationWindowViewModel = (INavigationWindowViewModel)Activator.CreateInstance(typeof(TNavigationWindowViewModel), currentNavigationWindowService)!;
            navigationWindow.DataContext = navigationWindowViewModel;
        
            return navigationWindow;
        });
    }
}