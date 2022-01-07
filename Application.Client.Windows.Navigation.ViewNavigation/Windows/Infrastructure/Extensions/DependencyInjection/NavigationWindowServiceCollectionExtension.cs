using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.ViewModels.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Navigation.ViewNavigation.Windows.Infrastructure.Extensions.DependencyInjection;

public static class NavigationWindowServiceCollectionExtension
{
    public static void AddNavigationWindow<TNavigationWindow, TNavigationWindowViewModel>(this IServiceCollection @this) where TNavigationWindow : NavigationWindow.Abstractions.NavigationWindow
        where TNavigationWindowViewModel : NavigationWindowViewModelBase<TNavigationWindow>
    {
        @this.AddTransient(serviceProvider =>
        {
            TNavigationWindow navigationWindow = Activator.CreateInstance<TNavigationWindow>();

            Func<TNavigationWindow, IViewNavigationService<TNavigationWindow>> createViewNavigationService = serviceProvider.GetRequiredService<Func<TNavigationWindow, IViewNavigationService<TNavigationWindow>>>();
            IViewNavigationService<TNavigationWindow> viewNavigationService = createViewNavigationService(navigationWindow);

            TNavigationWindowViewModel navigationWindowViewModel = (TNavigationWindowViewModel)Activator.CreateInstance(typeof(TNavigationWindowViewModel), viewNavigationService)!;
            navigationWindow.DataContext = navigationWindowViewModel;

            return navigationWindow;
        });
    }
}