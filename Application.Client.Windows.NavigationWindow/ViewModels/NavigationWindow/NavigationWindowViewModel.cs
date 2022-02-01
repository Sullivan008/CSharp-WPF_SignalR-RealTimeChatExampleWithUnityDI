using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow;
using Application.Client.Windows.ContentPresenter.ViewModels.ContentPresenter.Interfaces;
using Application.Client.Windows.NavigationWindow.PageViews.ViewModels.PageView.Interfaces;
using Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindowSettings.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow;

public class NavigationWindowViewModel<TNavigationWindowSettingsViewModel> : ApplicationWindowViewModel<TNavigationWindowSettingsViewModel>, INavigationWindowViewModel
    where TNavigationWindowSettingsViewModel : INavigationWindowSettingsViewModel, new()
{
    private readonly ICurrentNavigationWindowService _currentNavigationWindowService;

    public NavigationWindowViewModel(ICurrentNavigationWindowService currentNavigationWindowService)
    {
        _currentNavigationWindowService = currentNavigationWindowService;
    }

    ICurrentNavigationWindowService INavigationWindowViewModel.CurrentNavigationWindowService => _currentNavigationWindowService;

    private IContentPresenterViewModel? _currentPage;
    public IContentPresenterViewModel CurrentPage
    {
        get
        {
            Guard.ThrowIfNull(_currentPage, nameof(CurrentPage));

            return _currentPage!;
        }

        set
        {
            Guard.ThrowIfNull(value, nameof(CurrentPage));
            _currentPage = value;

            OnPropertyChanged();
        }
    }

}