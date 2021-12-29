using Application.Client.Common.ViewModels;
using Application.Client.Navigation.ViewNavigation.Abstractions.Windows;
using Application.Client.Navigation.ViewNavigation.Services.Interfaces;

namespace Application.Client.Navigation.ViewNavigation.Abstractions.ViewModels;

public abstract class NavigationWindowPageViewModelBase<TNavigationWindow> : ViewModelBase where TNavigationWindow : NavigationWindow
{
    protected readonly IViewNavigationService<TNavigationWindow> ViewNavigationService;

    protected NavigationWindowPageViewModelBase(IViewNavigationService<TNavigationWindow> viewNavigationService)
    {
        ViewNavigationService = viewNavigationService;
    }
}