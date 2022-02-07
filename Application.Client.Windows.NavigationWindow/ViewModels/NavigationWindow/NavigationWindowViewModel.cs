using Application.Client.Windows.Common.ContentPresenter.ViewModels.ContentPresenter.Interfaces;
using Application.Client.Windows.Core.ViewModels.Window;
using Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindowSettings.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow;

public class NavigationWindowViewModel<TNavigationWindowSettingsViewModel> : WindowViewModel<TNavigationWindowSettingsViewModel>, INavigationWindowViewModel
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