using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.Abstractions;
using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.Initializers.PageViewModelInitializer.Abstractions.Models;
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
    
    private PageViewModelBase? _currentPage;
    public PageViewModelBase CurrentPage
    {
        get => _currentPage!;
        set
        {
            Guard.ThrowIfNull(value, nameof(CurrentPage));

            _currentPage = value;
            OnPropertyChanged();
        }
    }

    internal void Navigate<TPageViewModel>() where TPageViewModel : PageViewModelBase
    {
        ViewNavigationService.Navigate<TPageViewModel>();
    }

    internal void Navigate<TPageViewModel, TPageViewModelInitializerModel>(Func<TPageViewModelInitializerModel> pageViewModelInitializerModelFactory) where TPageViewModel : PageViewModelBase
                                                                                                                                                                   where TPageViewModelInitializerModel : BasePageViewModelInitializerModel
    {
        ViewNavigationService.Navigate<TPageViewModel, TPageViewModelInitializerModel>(pageViewModelInitializerModelFactory);
    }
}