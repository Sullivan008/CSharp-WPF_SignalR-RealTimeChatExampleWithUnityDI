using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.Abstractions;
using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.Initializers.PageViewModelInitializer.Abstractions.Models;
using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.Initializers.PageViewModelInitializer.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.Abstractions;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.ViewModels.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation;

public class ViewNavigationService<TNavigationWindow> : IViewNavigationService<TNavigationWindow> where TNavigationWindow : NavigationWindow
{
    private readonly IServiceProvider _serviceProvider;

    private readonly TNavigationWindow _navigationWindow;

    public ViewNavigationService(IServiceProvider serviceProvider, TNavigationWindow navigationWindow)
    {
        _serviceProvider = serviceProvider;
        _navigationWindow = navigationWindow;
    }

    public void Navigate<TPageViewModel>() where TPageViewModel : PageViewModelBase<TNavigationWindow>
    {
        TPageViewModel pageViewModel = GetPageViewModel<TPageViewModel>();

        ((NavigationWindowViewModelBase<TNavigationWindow>)_navigationWindow.DataContext).CurrentPage = pageViewModel;
    }

    public void Navigate<TPageViewModel, TPageViewModelInitializer>(Func<TPageViewModelInitializer> pageViewModelInitializerFactory) where TPageViewModel : PageViewModelBase<TNavigationWindow>
                                                                                                                                     where TPageViewModelInitializer : BasePageViewModelInitializerModel
    {
        TPageViewModel pageViewModel = GetPageViewModel<TPageViewModel>();

        InitializePageViewModel(pageViewModel, pageViewModelInitializerFactory);

        ((NavigationWindowViewModelBase<TNavigationWindow>)_navigationWindow.DataContext).CurrentPage = pageViewModel;
    }

    private TPageViewModel GetPageViewModel<TPageViewModel>() where TPageViewModel : PageViewModelBase<TNavigationWindow>
    {
        Func<IViewNavigationService<TNavigationWindow>, TPageViewModel> pageViewModelFactory =
            _serviceProvider.GetRequiredService<Func<IViewNavigationService<TNavigationWindow>, TPageViewModel>>();

        return pageViewModelFactory(this);
    }

    private void InitializePageViewModel<TPageViewModel, TPageViewModelInitializerModel>(TPageViewModel pageViewModel, 
        Func<TPageViewModelInitializerModel> pageViewModelInitializerFactory) where TPageViewModel : PageViewModelBase<TNavigationWindow> 
                                                                              where TPageViewModelInitializerModel : BasePageViewModelInitializerModel
    {
        IPageViewModelInitializer<TNavigationWindow, TPageViewModel, TPageViewModelInitializerModel> pageViewModelInitializer =
            _serviceProvider.GetRequiredService<IPageViewModelInitializer<TNavigationWindow, TPageViewModel, TPageViewModelInitializerModel>>();

        TPageViewModelInitializerModel pageViewModelInitializerModel = pageViewModelInitializerFactory();

        pageViewModelInitializer.Initialize(pageViewModel, pageViewModelInitializerModel);
    }
}