using Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation.Interfaces;
using Application.Client.Windows.NavigationWindow.PageViews.ViewModels.PageView.Interfaces;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindowSettings.Interfaces;
using Application.Client.Windows.Windows.ApplicationWindow.ViewModels.Abstractions;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow;

public class NavigationWindowViewModel<TNavigationWindowSettingsViewModel> : ApplicationWindowViewModelBase<TNavigationWindowSettingsViewModel>, INavigationWindowViewModel
    where TNavigationWindowSettingsViewModel : INavigationWindowSettingsViewModel, new()
{
    public IPageViewNavigationService PageViewNavigationService { get; }

    protected NavigationWindowViewModel(IPageViewNavigationService pageViewNavigationService)
    {
        PageViewNavigationService = pageViewNavigationService;
    }

    private IPageViewViewModel? _currentPage;
    public IPageViewViewModel CurrentPage
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