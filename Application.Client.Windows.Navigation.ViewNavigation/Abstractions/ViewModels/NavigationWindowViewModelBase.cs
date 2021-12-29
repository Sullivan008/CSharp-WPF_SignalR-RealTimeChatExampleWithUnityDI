using Application.Client.Windows.Abstractions.ViewModels;
using Application.Client.Windows.Navigation.ViewNavigation.Abstractions.Windows;
using Application.Client.Windows.Navigation.ViewNavigation.Services.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Navigation.ViewNavigation.Abstractions.ViewModels;

public abstract class NavigationWindowViewModelBase<TNavigationWindow> : ApplicationWindowViewModelBase where TNavigationWindow : NavigationWindow
{
    protected readonly IViewNavigationService<TNavigationWindow> ViewNavigationService;

    protected NavigationWindowViewModelBase(IViewNavigationService<TNavigationWindow> viewNavigationService)
    {
        ViewNavigationService = viewNavigationService;
    }

    private NavigationWindowPageViewModelBase<TNavigationWindow>? _currentPage;
    public NavigationWindowPageViewModelBase<TNavigationWindow> CurrentPage
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