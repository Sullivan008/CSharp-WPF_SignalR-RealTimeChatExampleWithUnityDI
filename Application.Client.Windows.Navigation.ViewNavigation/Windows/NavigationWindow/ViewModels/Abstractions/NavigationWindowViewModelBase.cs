using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModelInitializers.PageViewModelInitializer.InitializerModels.Abstractions;
using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModelInitializers.PageViewModelInitializer.InitializerModels.Interfaces.Markers;
using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.PageViewModel.Interfaces.Markers;
using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;
using Application.Client.Windows.Windows.ApplicationWindow.ViewModels.Abstractions;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.ViewModels.Abstractions;

public abstract class NavigationWindowViewModelBase : ApplicationWindowViewModelBase
{
    protected readonly IViewNavigationService ViewNavigationService;

    protected NavigationWindowViewModelBase(IViewNavigationService viewNavigationService)
    {
        ViewNavigationService = viewNavigationService;
    }
    
    private IPageViewModel? _currentPage;
    public IPageViewModel CurrentPage
    {
        get => _currentPage!;
        set
        {
            Guard.ThrowIfNull(value, nameof(CurrentPage));

            _currentPage = value;
            OnPropertyChanged();
        }
    }

    internal void Navigate<TPageViewModel>() where TPageViewModel : IPageViewModel
    {
        ViewNavigationService.Navigate<TPageViewModel>();
    }

    internal void Navigate<TPageViewModel, TPageViewModelInitializerModel>(Func<TPageViewModelInitializerModel> pageViewModelInitializerModelFactory) where TPageViewModel : IPageViewModel
                                                                                                                                                      where TPageViewModelInitializerModel : IPageViewModelInitializerModel
    {
        ViewNavigationService.Navigate<TPageViewModel, TPageViewModelInitializerModel>(pageViewModelInitializerModelFactory);
    }
}