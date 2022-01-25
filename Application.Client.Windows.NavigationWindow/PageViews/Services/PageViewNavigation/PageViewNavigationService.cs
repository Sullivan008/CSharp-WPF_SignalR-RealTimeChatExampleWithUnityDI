using System.Reflection;
using Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation.Interfaces;
using Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation.Options.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.PageViews.ViewModels.PageView.Initializers.Interfaces;
using Application.Client.Windows.NavigationWindow.PageViews.ViewModels.PageView.Initializers.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.PageViews.ViewModels.PageView.Interfaces;
using Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation;

public class PageViewNavigationService : IPageViewNavigationService
{
    private readonly IServiceProvider _serviceProvider;

    private readonly ICurrentNavigationWindowService _currentNavigationWindowService;

    public PageViewNavigationService(IServiceProvider serviceProvider, ICurrentNavigationWindowService currentNavigationWindowService)
    {
        _serviceProvider = serviceProvider;
        _currentNavigationWindowService = currentNavigationWindowService;
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
        Type pageViewViewModelFactoryType = typeof(Func<,,>)
            .MakeGenericType(typeof(IPageViewNavigationService), typeof(ICurrentNavigationWindowService), pageViewViewModelType);

        Func<IPageViewNavigationService, ICurrentNavigationWindowService, IPageViewViewModel> pageViewViewModelFactory =
            (Func<IPageViewNavigationService, ICurrentNavigationWindowService, IPageViewViewModel>)_serviceProvider.GetRequiredService(pageViewViewModelFactoryType);

        return pageViewViewModelFactory(this, _currentNavigationWindowService);
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
        INavigationWindowViewModel navigationWindowViewModel = (INavigationWindowViewModel) _currentNavigationWindowService.NavigationWindow.DataContext;

        navigationWindowViewModel.CurrentPage = pageViewViewModel;
    }
}