using System.Reflection;
using Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation.Interfaces;
using Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation.Options.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.PageViews.ViewModels.PageView.Initializers.Interfaces;
using Application.Client.Windows.NavigationWindow.PageViews.ViewModels.PageView.Initializers.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.PageViews.ViewModels.PageView.Interfaces;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.Window.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation;

public class PageViewNavigationService : IPageViewNavigationService
{
    private readonly IServiceProvider _serviceProvider;

    private readonly INavigationWindow _navigationWindow;

    public PageViewNavigationService(IServiceProvider serviceProvider, INavigationWindow navigationWindow)
    {
        _serviceProvider = serviceProvider;
        _navigationWindow = navigationWindow;
    }

    public void Navigate(IPageViewNavigationOptions pageViewNavigationOptions)
    {
        IPageViewViewModel pageViewModel = GetPageViewViewModel(pageViewNavigationOptions.PageViewViewModelType);

        InitializePageViewViewModel(pageViewNavigationOptions.PageViewViewModelType, pageViewModel,
            pageViewNavigationOptions.PageViewViewModelInitializerModelType, pageViewNavigationOptions.PageViewViewModelInitializerModel);

        SetCurrentPage(pageViewModel);
    }

    private IPageViewViewModel GetPageViewViewModel(Type pageViewViewModelType)
    {
        Type pageViewViewModelFactoryType = typeof(Func<,>)
            .MakeGenericType(typeof(IPageViewNavigationService), pageViewViewModelType);

        Func<IPageViewNavigationService, IPageViewViewModel> pageViewViewModelFactory = 
            (Func<IPageViewNavigationService, IPageViewViewModel>)_serviceProvider.GetRequiredService(pageViewViewModelFactoryType);

        return pageViewViewModelFactory(this);
    }
    
    private void InitializePageViewViewModel(Type pageViewViewModelType, IPageViewViewModel pageViewViewModel,
        Type pageViewViewModelInitializerModelType, IPageViewViewModelInitializerModel? pageViewViewModelInitializerModel)
    {
        if (pageViewViewModelInitializerModel != null)
        {
            Type pageViewViewModelInitializerType = typeof(IPageViewViewModelInitializer<,>)
                .MakeGenericType(pageViewViewModelType, pageViewViewModelInitializerModelType);

            MethodInfo pageViewViewModelInitializerInitializeMethodInfo = pageViewViewModelInitializerType
                .GetMethods()
                .Single();

            var navigationWindowViewModelInitializer =
                _serviceProvider.GetRequiredService(pageViewViewModelInitializerType);

            pageViewViewModelInitializerInitializeMethodInfo
                .Invoke(navigationWindowViewModelInitializer, new object[] { pageViewViewModel, pageViewViewModelInitializerModel });
        }
    }

    private void SetCurrentPage(IPageViewViewModel pageViewViewModel)
    {
        ((INavigationWindowViewModel)_navigationWindow.DataContext).CurrentPage = pageViewViewModel;
    }
}