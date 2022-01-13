using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.Abstractions;
using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.Initializers.PageViewModelInitializer.Abstractions.Models;
using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.Initializers.PageViewModelInitializer.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.Abstractions.Window;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.ViewModels.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation;

public class ViewNavigationService : IViewNavigationService
{
    private readonly IServiceProvider _serviceProvider;

    private readonly NavigationWindow _navigationWindow;

    public ViewNavigationService(IServiceProvider serviceProvider, NavigationWindow navigationWindow)
    {
        _serviceProvider = serviceProvider;
        _navigationWindow = navigationWindow;
    }

    public void Navigate<TPageViewModel>() where TPageViewModel : PageViewModelBase
    {
        TPageViewModel pageViewModel = GetPageViewModel<TPageViewModel>();

        ((NavigationWindowViewModelBase)_navigationWindow.DataContext).CurrentPage = pageViewModel;
    }

    public void Navigate<TPageViewModel, TPageViewModelInitializer>(Func<TPageViewModelInitializer> pageViewModelInitializerFactory) where TPageViewModel : PageViewModelBase
                                                                                                                                     where TPageViewModelInitializer : BasePageViewModelInitializerModel
    {
        TPageViewModel pageViewModel = GetPageViewModel<TPageViewModel>();

        InitializePageViewModel(pageViewModel, pageViewModelInitializerFactory);

        ((NavigationWindowViewModelBase)_navigationWindow.DataContext).CurrentPage = pageViewModel;
    }

    private TPageViewModel GetPageViewModel<TPageViewModel>() where TPageViewModel : PageViewModelBase
    {
        Func<IViewNavigationService, TPageViewModel> pageViewModelFactory =
            _serviceProvider.GetRequiredService<Func<IViewNavigationService, TPageViewModel>>();

        return pageViewModelFactory(this);
    }

    private void InitializePageViewModel<TPageViewModel, TPageViewModelInitializerModel>(TPageViewModel pageViewModel, 
        Func<TPageViewModelInitializerModel> pageViewModelInitializerFactory) where TPageViewModel : PageViewModelBase 
                                                                              where TPageViewModelInitializerModel : BasePageViewModelInitializerModel
    {
        IPageViewModelInitializer<TPageViewModel, TPageViewModelInitializerModel> pageViewModelInitializer =
            _serviceProvider.GetRequiredService<IPageViewModelInitializer<TPageViewModel, TPageViewModelInitializerModel>>();

        TPageViewModelInitializerModel pageViewModelInitializerModel = pageViewModelInitializerFactory();

        pageViewModelInitializer.Initialize(pageViewModel, pageViewModelInitializerModel);
    }
}