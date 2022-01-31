using System.Reflection;
using Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation.Interfaces;
using Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation.Options.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindowSettings.Initializers.Interfaces;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindowSettings.Initializers.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindowSettings.Interfaces;
using Application.Client.Windows.NavigationWindow.Window.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow;

public class CurrentNavigationWindowService : ICurrentNavigationWindowService
{
    private readonly IServiceProvider _serviceProvider;

    private readonly INavigationWindow _navigationWindow;

    private readonly IPageViewNavigationService _pageViewNavigationService;

    public CurrentNavigationWindowService(IServiceProvider serviceProvider, INavigationWindow navigationWindow, IPageViewNavigationService pageViewNavigationService)
    {
        _serviceProvider = serviceProvider;
        _navigationWindow = navigationWindow;
        _pageViewNavigationService = pageViewNavigationService;
    }

    INavigationWindow ICurrentNavigationWindowService.NavigationWindow => _navigationWindow;

    public void ReInitializeWindowSettings(Func<INavigationWindowSettingsViewModelInitializerModel> navigationWindowSettingsViewModelInitializerModelFactory)
    {
        INavigationWindowViewModel navigationWindowViewModel = (INavigationWindowViewModel)_navigationWindow.DataContext;
        INavigationWindowSettingsViewModel navigationWindowSettingsViewModel = (INavigationWindowSettingsViewModel)navigationWindowViewModel.WindowSettings;

        INavigationWindowSettingsViewModelInitializerModel navigationWindowSettingsViewModelInitializerModel = navigationWindowSettingsViewModelInitializerModelFactory();

        Type navigationWindowSettingsViewModelType = navigationWindowSettingsViewModel.GetType();
        Type navigationWindowSettingsViewModelInitializerModelType = navigationWindowSettingsViewModelInitializerModel.GetType();

        Type navigationWindowSettingsViewModelInitializerType = typeof(INavigationWindowSettingsViewModelInitializer<,>)
            .MakeGenericType(navigationWindowSettingsViewModelType, navigationWindowSettingsViewModelInitializerModelType);

        MethodInfo navigationWindowSettingsViewModelInitializerInitializeMethodInfo = navigationWindowSettingsViewModelInitializerType
            .GetMethods()
            .Single();

        object navigationWindowSettingsViewModelInitializer =
            _serviceProvider.GetRequiredService(navigationWindowSettingsViewModelInitializerType);

        navigationWindowSettingsViewModelInitializerInitializeMethodInfo
            .Invoke(navigationWindowSettingsViewModelInitializer, new object[] { navigationWindowSettingsViewModel, navigationWindowSettingsViewModelInitializerModel });
    }

    public void Navigate(IPageViewNavigationOptions pageViewNavigationOptions)
    {
        _pageViewNavigationService.Navigate(pageViewNavigationOptions);
    }
}