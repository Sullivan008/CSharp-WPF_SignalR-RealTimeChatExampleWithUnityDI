using System.Reflection;
using Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation.Interfaces;
using Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation.Options.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.PageViews.ViewModels.PageView.Initializers.Interfaces;
using Application.Client.Windows.NavigationWindow.PageViews.ViewModels.PageView.Initializers.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.PageViews.ViewModels.PageView.Interfaces;
using Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.Window.Interfaces;
using Application.Common.Utilities.Guard;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation;

internal class PageViewNavigationService : IPageViewNavigationService
{
    private readonly IServiceProvider _serviceProvider;

    private ICurrentNavigationWindowService? _currentNavigationWindowService;

    public PageViewNavigationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    ICurrentNavigationWindowService IPageViewNavigationService.CurrentNavigationWindowService
    {
        set
        {
            Guard.ThrowIfNotNull(_currentNavigationWindowService, nameof(_currentNavigationWindowService));
            Guard.ThrowIfNull(value, nameof(IPageViewNavigationService.CurrentNavigationWindowService));

            _currentNavigationWindowService = value;
        }
    }

    void IPageViewNavigationService.Navigate(IPageViewNavigationOptions pageViewNavigationOptions)
    {
        Guard.ThrowIfNull(_currentNavigationWindowService, nameof(_currentNavigationWindowService));

        IPageViewViewModel pageViewModel = GetPageViewViewModel(pageViewNavigationOptions.PageViewViewModelType);

        InitializePageViewViewModel(pageViewNavigationOptions.PageViewViewModelType, pageViewModel,
            pageViewNavigationOptions.PageViewViewModelInitializerModelType, pageViewNavigationOptions.PageViewViewModelInitializerModel);

        SetCurrentPage(_currentNavigationWindowService!.NavigationWindow, pageViewModel);
    }

    private IPageViewViewModel GetPageViewViewModel(Type pageViewViewModelType)
    {
        Type pageViewViewModelFactoryType = typeof(Func<,>)
            .MakeGenericType(typeof(ICurrentNavigationWindowService), pageViewViewModelType);

        Func<ICurrentNavigationWindowService, IPageViewViewModel> pageViewViewModelFactory =
            (Func<ICurrentNavigationWindowService, IPageViewViewModel>)_serviceProvider.GetRequiredService(pageViewViewModelFactoryType);

        return pageViewViewModelFactory(_currentNavigationWindowService!);
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

    private static void SetCurrentPage(INavigationWindow navigationWindow, IPageViewViewModel pageViewViewModel)
    {
        INavigationWindowViewModel navigationWindowViewModel = (INavigationWindowViewModel)navigationWindow.DataContext;

        navigationWindowViewModel.CurrentPage = pageViewViewModel;
    }
}