using Application.Client.Windows.Navigation.ViewNavigation.Abstractions.ViewModels;
using Application.Client.Windows.Navigation.ViewNavigation.Abstractions.Windows;
using Application.Client.Windows.Navigation.ViewNavigation.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Navigation.ViewNavigation.Services;

public class ViewNavigationService<TNavigationWindow> : IViewNavigationService<TNavigationWindow> where TNavigationWindow : NavigationWindow
{
    private readonly IServiceProvider _serviceProvider;

    private readonly TNavigationWindow _navigationWindow;

    public ViewNavigationService(IServiceProvider serviceProvider, TNavigationWindow navigationWindow)
    {
        _serviceProvider = serviceProvider;
        _navigationWindow = navigationWindow;
    }

    public void Navigate<TPageViewModelType>() where TPageViewModelType : NavigationWindowPageViewModelBase<TNavigationWindow>
    {
        Func<IViewNavigationService<TNavigationWindow>, TPageViewModelType> navigationWindowPageViewModelFactory =
            _serviceProvider.GetRequiredService<Func<IViewNavigationService<TNavigationWindow>, TPageViewModelType>>();

        TPageViewModelType navigationWindowPageViewModel = navigationWindowPageViewModelFactory(this);

        ((NavigationWindowViewModelBase<TNavigationWindow>)_navigationWindow.DataContext).CurrentPage = navigationWindowPageViewModel;
    }
}