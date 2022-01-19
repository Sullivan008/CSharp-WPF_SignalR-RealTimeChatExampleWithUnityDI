using System.Reflection;
using Application.Client.Windows.Navigation.ViewNavigation.PageViews.ViewModels.PageView.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Services.NavigationWindow.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Services.NavigationWindow.Options.Models;
using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Options;
using Application.Client.Windows.Navigation.ViewNavigation.ViewModels.NavigationWindow.Initializers.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.ViewModels.NavigationWindow.Initializers.Models.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.ViewModels.NavigationWindow.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Navigation.ViewNavigation.Services.NavigationWindow;

public class NavigationWindowService : INavigationWindowService
{
    private readonly IServiceProvider _serviceProvider;

    public NavigationWindowService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task ShowAsync<TPageViewModel>(INavigationWindowOptionsModel navigationWindowOptions) where TPageViewModel : IPageViewViewModel
    {
        INavigationWindow navigationWindow = GetNavigationWindow(navigationWindowOptions.WindowType);

        InitializeNavigationWindow((INavigationWindowViewModel)navigationWindow.DataContext,
                                   (INavigationWindowViewModelInitializerModel)navigationWindowOptions.WindowViewModelInitializerModel);

        //Navigate<TPageViewModel>((INavigationWindowViewModel)navigationWindow.DataContext, navigationWindowOptions.ViewNavigationOptions);

        navigationWindow.Show();

        await Task.CompletedTask;
    }
    
    private INavigationWindow GetNavigationWindow(Type navigationWindowType)
    {
        return (INavigationWindow)_serviceProvider.GetRequiredService(navigationWindowType);
    }

    private void InitializeNavigationWindow(INavigationWindowViewModel navigationWindowViewModel, INavigationWindowViewModelInitializerModel navigationWindowViewModelInitializerModel)

    {
        const string navigationWindowViewModelInitializerInitializeMethodName =
            nameof(INavigationWindowViewModelInitializer<INavigationWindowViewModel, INavigationWindowViewModelInitializerModel>.Initialize);

        Type navigationWindowViewModelType = navigationWindowViewModel.GetType();
        Type navigationWindowViewModelInitializerModelType = navigationWindowViewModelInitializerModel.GetType();

        Type navigationWindowViewModelInitializerType = 
            typeof(INavigationWindowViewModelInitializer<,>).MakeGenericType(navigationWindowViewModelType, navigationWindowViewModelInitializerModelType);

        MethodInfo navigationWindowViewModelInitializerInitializeMethodInfo = 
            navigationWindowViewModelInitializerType.GetMethod(navigationWindowViewModelInitializerInitializeMethodName)!;

        var navigationWindowViewModelInitializer = 
            _serviceProvider.GetRequiredService(navigationWindowViewModelInitializerType);

        navigationWindowViewModelInitializerInitializeMethodInfo
            .Invoke(navigationWindowViewModelInitializer, new object[] {navigationWindowViewModel, navigationWindowViewModelInitializerModel});
    }

    private static void Navigate<TPageViewModel>(INavigationWindowViewModel navigationWindowViewModel, IViewNavigationOptions? viewNavigationOptions) where TPageViewModel : IPageViewViewModel
    {
        navigationWindowViewModel.ViewNavigationService.Navigate<TPageViewModel>(viewNavigationOptions);
    }
}