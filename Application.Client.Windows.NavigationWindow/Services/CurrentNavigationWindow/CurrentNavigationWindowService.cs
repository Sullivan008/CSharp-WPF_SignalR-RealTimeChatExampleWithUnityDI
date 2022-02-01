using System.Reflection;
using Application.Client.Windows.ApplicationWindow.Services.CurrentApplicationWindow.Interfaces;
using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindowSettings.Initializers.Models.Interfaces;
using Application.Client.Windows.ApplicationWindow.Window.Interfaces;
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

    public CurrentNavigationWindowService(IServiceProvider serviceProvider, INavigationWindow navigationWindow)
    {
        _serviceProvider = serviceProvider;
        _navigationWindow = navigationWindow;
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
        ((INavigationWindowViewModel)_navigationWindow.DataContext).CurrentPage = pageViewNavigationOptions.
        _pageViewNavigationService.Navigate(pageViewNavigationOptions);
    }

    IApplicationWindow ICurrentApplicationWindowService.ApplicationWindow => _navigationWindow;
    public void ReInitializeWindowSettings(Func<IApplicationWindowSettingsViewModelInitializerModel> applicationWindowSettingsViewModelInitializerModelFactory)
    {
        throw new NotImplementedException();
    }
}