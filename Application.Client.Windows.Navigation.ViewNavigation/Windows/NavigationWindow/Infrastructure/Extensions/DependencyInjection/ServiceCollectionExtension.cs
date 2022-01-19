using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.ViewModels.NavigationWindow.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static void AddNavigationWindow<TNavigationWindow, TNavigationWindowViewModel>(this IServiceCollection @this) where TNavigationWindow : INavigationWindow
                                                                                                                         where TNavigationWindowViewModel : INavigationWindowViewModel
    {
        @this.AddTransient(typeof(TNavigationWindow), serviceProvider =>
        {
            TNavigationWindow navigationWindow = Activator.CreateInstance<TNavigationWindow>();

            Func<TNavigationWindow, IViewNavigationService> createViewNavigationService =
                serviceProvider.GetRequiredService<Func<TNavigationWindow, IViewNavigationService>>();

            IViewNavigationService viewNavigationService = createViewNavigationService(navigationWindow);

            TNavigationWindowViewModel navigationWindowViewModel = (TNavigationWindowViewModel)Activator.CreateInstance(typeof(TNavigationWindowViewModel), viewNavigationService)!;
            navigationWindow.DataContext = navigationWindowViewModel;
        
            return navigationWindow;
        });
    }
}