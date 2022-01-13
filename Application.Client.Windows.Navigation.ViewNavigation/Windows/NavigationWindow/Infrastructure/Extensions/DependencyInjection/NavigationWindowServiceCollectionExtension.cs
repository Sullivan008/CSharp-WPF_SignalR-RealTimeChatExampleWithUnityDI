using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.ViewModels.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.Infrastructure.Extensions.DependencyInjection;

public static class NavigationWindowServiceCollectionExtension
{
    public static void AddNavigationWindow<TNavigationWindow, TNavigationWindowViewModel, TNavigationWindowSettingsViewModel>(this IServiceCollection @this)
        where TNavigationWindow : Abstractions.Window.NavigationWindow
        where TNavigationWindowViewModel : NavigationWindowViewModelBase
        where TNavigationWindowSettingsViewModel : NavigationWindowSettingsViewModelBase
    {
        @this.AddTransient(serviceProvider =>
        {
            TNavigationWindow navigationWindow = Activator.CreateInstance<TNavigationWindow>();

            Func<TNavigationWindow, IViewNavigationService> createViewNavigationService = 
                serviceProvider.GetRequiredService<Func<TNavigationWindow, IViewNavigationService>>();

            IViewNavigationService viewNavigationService = createViewNavigationService(navigationWindow);

            TNavigationWindowViewModel navigationWindowViewModel = (TNavigationWindowViewModel)Activator.CreateInstance(typeof(TNavigationWindowViewModel), viewNavigationService)!;
            navigationWindowViewModel.WindowSettings = Activator.CreateInstance<TNavigationWindowSettingsViewModel>();

            navigationWindow.DataContext = navigationWindowViewModel;

            return navigationWindow;
        });
    }
}