using Application.Client.Common.ViewModels;
using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;

namespace Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.Abstractions;

public abstract class PageViewModelBase : ViewModelBase
{
    protected readonly IViewNavigationService ViewNavigationService;

    protected PageViewModelBase(IViewNavigationService viewNavigationService)
    {
        ViewNavigationService = viewNavigationService;
    }
}