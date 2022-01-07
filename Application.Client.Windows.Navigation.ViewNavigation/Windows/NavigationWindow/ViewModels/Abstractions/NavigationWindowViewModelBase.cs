using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.Abstractions;
using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;
using Application.Client.Windows.Windows.ApplicationWindow.ViewModels.Abstractions;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.ViewModels.Abstractions;

public abstract class NavigationWindowViewModelBase<TNavigationWindow> : ApplicationWindowViewModelBase where TNavigationWindow : NavigationWindow.Abstractions.NavigationWindow
{
    protected readonly IViewNavigationService<TNavigationWindow> ViewNavigationService;

    protected NavigationWindowViewModelBase(IViewNavigationService<TNavigationWindow> viewNavigationService)
    {
        ViewNavigationService = viewNavigationService;
    }

    private PageViewModelBase<TNavigationWindow>? _currentPage;
    public PageViewModelBase<TNavigationWindow> CurrentPage
    {
        get => _currentPage!;
        set
        {
            Guard.ThrowIfNull(value, nameof(CurrentPage));

            _currentPage = value;
            OnPropertyChanged();
        }
    }
}