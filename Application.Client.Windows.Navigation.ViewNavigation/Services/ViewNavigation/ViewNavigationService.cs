using System.Reflection;
using Application.Client.Windows.Navigation.ViewNavigation.PageViews.ViewModels.PageView.Initializers.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.PageViews.ViewModels.PageView.Initializers.Models.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.PageViews.ViewModels.PageView.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Options;
using Application.Client.Windows.Navigation.ViewNavigation.ViewModels.NavigationWindow.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation;

public class ViewNavigationService : IViewNavigationService
{
    private readonly IServiceProvider _serviceProvider;

    private readonly INavigationWindow _navigationWindow;

    public ViewNavigationService(IServiceProvider serviceProvider, INavigationWindow navigationWindow)
    {
        _serviceProvider = serviceProvider;
        _navigationWindow = navigationWindow;
    }

    public void Navigate<TPageViewModel>() where TPageViewModel : IPageViewViewModel
    {
        TPageViewModel pageViewModel = GetPageViewModel<TPageViewModel>();

        SetCurrentPage(pageViewModel);
    }

    public void Navigate<TPageViewModel>(IViewNavigationOptions viewNavigationOptions) where TPageViewModel : IPageViewViewModel
    {
        TPageViewModel pageViewModel = GetPageViewModel<TPageViewModel>();

        if (viewNavigationOptions.PageViewViewModelInitializerModel != null)
        {
            InitializePageViewModel(pageViewModel, viewNavigationOptions.PageViewViewModelInitializerModel);
        }

        SetCurrentPage(pageViewModel);
    }

    private void InitializePageViewModel(IPageViewViewModel pageViewModel, IPageViewViewModelInitializerModel pageViewViewModelInitializerModel)
    {
        Type pageViewViewModelType = pageViewModel.GetType();
        Type pageViewViewModelInitializerModelType = pageViewViewModelInitializerModel.GetType();

        Type pageViewViewModelInitializerType =
            typeof(IPageViewViewModelInitializer<,>).MakeGenericType(pageViewViewModelType, pageViewViewModelInitializerModelType);

        MethodInfo pageViewViewModelInitializerInitializeMethodInfo =
            pageViewViewModelInitializerType.GetMethods().Single();

        var navigationWindowViewModelInitializer =
            _serviceProvider.GetRequiredService(pageViewViewModelInitializerType);

        pageViewViewModelInitializerInitializeMethodInfo
            .Invoke(navigationWindowViewModelInitializer, new object[] { pageViewModel, pageViewViewModelInitializerModel });
    }

    private TPageViewModel GetPageViewModel<TPageViewModel>() where TPageViewModel : IPageViewViewModel
    {
        Func<IViewNavigationService, TPageViewModel> pageViewModelFactory = 
            _serviceProvider.GetRequiredService<Func<IViewNavigationService, TPageViewModel>>();

        return pageViewModelFactory(this);
    }

    private void SetCurrentPage<TPageViewModel>(TPageViewModel pageViewModel) where TPageViewModel : IPageViewViewModel
    {
        ((INavigationWindowViewModel)_navigationWindow.DataContext).CurrentPage = pageViewModel;
    }
}