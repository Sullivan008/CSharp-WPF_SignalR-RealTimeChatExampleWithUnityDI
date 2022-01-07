using Application.Client.Common.ViewModels;
using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.Abstractions;

namespace Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.Abstractions;

public abstract class PageViewModelBase<TNavigationWindow> : ViewModelBase where TNavigationWindow : NavigationWindow
{
    protected readonly IViewNavigationService<TNavigationWindow> ViewNavigationService;

    protected PageViewModelBase(IViewNavigationService<TNavigationWindow> viewNavigationService)
    {
        ViewNavigationService = viewNavigationService;
    }
}