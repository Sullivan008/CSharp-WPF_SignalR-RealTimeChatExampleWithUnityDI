using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModelInitializers.PageViewModelInitializer.InitializerModels.Interfaces.Markers;
using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModelInitializers.PageViewModelInitializer.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.PageViewModel.Interfaces.Markers;
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

    public void Navigate<TPageViewModel>() where TPageViewModel : IPageViewModel
    {
        TPageViewModel pageViewModel = GetPageViewModel<TPageViewModel>();

        SetCurrentPage(pageViewModel);
    }

    public void Navigate<TPageViewModel, TPageViewModelInitializerModel>(Func<TPageViewModelInitializerModel> pageViewModelInitializerModelFactory) where TPageViewModel : IPageViewModel
                                                                                                                                                    where TPageViewModelInitializerModel : IPageViewModelInitializerModel
    {
        TPageViewModel pageViewModel = GetPageViewModel<TPageViewModel>();

        InitializePageViewModel(pageViewModel, pageViewModelInitializerModelFactory);
        
        SetCurrentPage(pageViewModel);
    }

    private void InitializePageViewModel<TPageViewModel, TPageViewModelInitializerModel>(TPageViewModel pageViewModel, Func<TPageViewModelInitializerModel> pageViewModelInitializerModelFactory) 
        where TPageViewModel : IPageViewModel
        where TPageViewModelInitializerModel : IPageViewModelInitializerModel
    {
        IPageViewModelInitializer<TPageViewModel, TPageViewModelInitializerModel> pageViewModelInitializer =
            _serviceProvider.GetRequiredService<IPageViewModelInitializer<TPageViewModel, TPageViewModelInitializerModel>>();

        TPageViewModelInitializerModel pageViewModelInitializerModel = pageViewModelInitializerModelFactory();

        pageViewModelInitializer.Initialize(pageViewModel, pageViewModelInitializerModel);
    }

    private TPageViewModel GetPageViewModel<TPageViewModel>() where TPageViewModel : IPageViewModel
    {
        Func<IViewNavigationService, TPageViewModel> pageViewModelFactory = 
            _serviceProvider.GetRequiredService<Func<IViewNavigationService, TPageViewModel>>();

        return pageViewModelFactory(this);
    }

    private void SetCurrentPage<TPageViewModel>(TPageViewModel pageViewModel) where TPageViewModel : IPageViewModel
    {
        ((NavigationWindowViewModelBase) _navigationWindow.DataContext).CurrentPage = pageViewModel;
    }
}