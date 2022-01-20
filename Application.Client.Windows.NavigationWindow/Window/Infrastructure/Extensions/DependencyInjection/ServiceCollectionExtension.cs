using Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation.Interfaces;
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

            Func<TNavigationWindow, IPageViewNavigationService> pageViewNavigationServiceFactory =
                serviceProvider.GetRequiredService<Func<TNavigationWindow, IPageViewNavigationService>>();

            IPageViewNavigationService pageViewNavigationService = pageViewNavigationServiceFactory(navigationWindow);

            INavigationWindowViewModel navigationWindowViewModel = (INavigationWindowViewModel)Activator.CreateInstance(typeof(TNavigationWindowViewModel), pageViewNavigationService)!;
            navigationWindow.DataContext = navigationWindowViewModel;
        
            return navigationWindow;
        });
    }
}