using Application.Client.Navigation.ViewNavigation.Abstractions.ViewModels;
using Application.Client.Navigation.ViewNavigation.Abstractions.Windows;
using Application.Client.Navigation.ViewNavigation.Services;
using Application.Client.Navigation.ViewNavigation.Services.Interfaces;
using Application.Common.Utilities.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Navigation.ViewNavigation.Infrastructure.Extensions.DependencyInjection;

public static class ViewNavigationServiceCollectionExtension
{
    public static IServiceCollection AddNavigationWindow<TNavigationWindow, TNavigationWindowViewModel>(this IServiceCollection @this,
        IReadOnlyDictionary<Type, Func<IServiceProvider, Func<IViewNavigationService<TNavigationWindow>, NavigationWindowPageViewModelBase<TNavigationWindow>>>> navigationWindowPageViewModelFactories)
        where TNavigationWindow : NavigationWindow
        where TNavigationWindowViewModel : NavigationWindowViewModelBase<TNavigationWindow>
    {
        @this.RegisterViewNavigationService<TNavigationWindow>();
        @this.RegisterNavigationWindow<TNavigationWindow, TNavigationWindowViewModel>();

        navigationWindowPageViewModelFactories.Keys.ForEach(key =>
        {
            @this.RegisterNavigationWindowPageViewModelFactory(key, navigationWindowPageViewModelFactories[key]);
        });

        return @this;
    }

    private static void RegisterViewNavigationService<TNavigationWindow>(this IServiceCollection @this) where TNavigationWindow : NavigationWindow
    {
        @this.AddTransient<Func<TNavigationWindow, IViewNavigationService<TNavigationWindow>>>(serviceProvider =>
        {
            return navigationWindow => new ViewNavigationService<TNavigationWindow>(serviceProvider, navigationWindow);
        });
    }

    private static void RegisterNavigationWindow<TNavigationWindow, TNavigationWindowViewModel>(this IServiceCollection @this)
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

    private static void RegisterNavigationWindowPageViewModelFactory<TNavigationWindow, TPageViewModel>(this IServiceCollection @this, Type serviceType,
        Func<IServiceProvider, Func<IViewNavigationService<TNavigationWindow>, TPageViewModel>> implementationFactory)
        where TNavigationWindow : NavigationWindow
        where TPageViewModel : NavigationWindowPageViewModelBase<TNavigationWindow>
    {
        @this.AddTransient(serviceType, implementationFactory);
    }
}