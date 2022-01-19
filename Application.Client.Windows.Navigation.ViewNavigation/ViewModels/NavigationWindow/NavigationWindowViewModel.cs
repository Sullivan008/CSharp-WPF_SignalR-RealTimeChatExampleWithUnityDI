using Application.Client.Windows.Navigation.ViewNavigation.PageViews.ViewModels.PageView.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.ViewModels.NavigationWindow.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.ViewModels.NavigationWindowSettings.Interfaces;
using Application.Client.Windows.Windows.ApplicationWindow.ViewModels.Abstractions;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Navigation.ViewNavigation.ViewModels.NavigationWindow;

public class NavigationWindowViewModel<TNavigationWindowSettingsViewModel> : ApplicationWindowViewModelBase<TNavigationWindowSettingsViewModel>, INavigationWindowViewModel
    where TNavigationWindowSettingsViewModel : INavigationWindowSettingsViewModel, new()
{
    public IViewNavigationService ViewNavigationService { get; }

    protected NavigationWindowViewModel(IViewNavigationService viewNavigationService)
    {
        ViewNavigationService = viewNavigationService;
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