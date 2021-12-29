using Application.Client.Common.ViewModels;
using Application.Client.Windows.Navigation.ViewNavigation.Abstractions.Windows;
using Application.Client.Windows.Navigation.ViewNavigation.Services.Interfaces;

namespace Application.Client.Windows.Navigation.ViewNavigation.Abstractions.ViewModels;

public abstract class NavigationWindowPageViewModelBase<TNavigationWindow> : ViewModelBase where TNavigationWindow : NavigationWindow
{
    protected readonly IViewNavigationService<TNavigationWindow> ViewNavigationService;

    protected NavigationWindowPageViewModelBase(IViewNavigationService<TNavigationWindow> viewNavigationService)
    {
        ViewNavigationService = viewNavigationService;
    }
}