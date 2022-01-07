using Application.Client.Windows.Navigation.ViewNavigation.Abstractions.ViewModels;
using Application.Client.Windows.Navigation.ViewNavigation.Abstractions.Windows;
using Application.Client.Windows.Navigation.ViewNavigation.Services;
using Application.Client.Windows.Navigation.ViewNavigation.Services.Interfaces;
using Application.Common.Utilities.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Navigation.ViewNavigation.Infrastructure.Extensions.DependencyInjection;

public static class ViewNavigationServiceCollectionExtension
{
    public static void RegisterViewNavigationService<TNavigationWindow>(this IServiceCollection @this) where TNavigationWindow : NavigationWindow
    {
        @this.AddTransient<Func<TNavigationWindow, IViewNavigationService<TNavigationWindow>>>(serviceProvider =>
        {
            return navigationWindow => new ViewNavigationService<TNavigationWindow>(serviceProvider, navigationWindow);
        });
    }

    public static void RegisterNavigationWindow<TNavigationWindow, TNavigationWindowViewModel>(this IServiceCollection @this)
        where TNavigationWindow : NavigationWindow
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

    public static void RegisterNavigationWindowPageViewModelInitializers(this IServiceCollection @this, IReadOnlyDictionary<Type, Type> navigationWindowPageViewModelInitializers)
    {
        navigationWindowPageViewModelInitializers.Keys.ForEach(key =>
        {
            @this.AddTransient(key, navigationWindowPageViewModelInitializers[key]);
        });
    }

    public static void RegisterNavigationWindowPageViewModelFactories<TNavigationWindow, TPageViewModel>(this IServiceCollection @this,
        IReadOnlyDictionary<Type, Func<IServiceProvider, Func<IViewNavigationService<TNavigationWindow>, TPageViewModel>>> navigationWindowPageViewModelFactories) where TNavigationWindow : NavigationWindow 
                                                                                                                                                                   where TPageViewModel : NavigationWindowPageViewModelBase<TNavigationWindow>
    {
        navigationWindowPageViewModelFactories.Keys.ForEach(key =>
        {
            @this.AddTransient(key, navigationWindowPageViewModelFactories[key]);
        });
    }
}