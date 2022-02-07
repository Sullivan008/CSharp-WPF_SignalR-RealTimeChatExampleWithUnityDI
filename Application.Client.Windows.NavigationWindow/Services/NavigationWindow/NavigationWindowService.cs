using System.Reflection;
using Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation.Options.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.Services.NavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.Services.NavigationWindow.Options.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Initializers.Interfaces;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Initializers.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.Window.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.NavigationWindow.Services.NavigationWindow;

public class NavigationWindowService : INavigationWindowService
{
    private readonly IServiceProvider _serviceProvider;

    public NavigationWindowService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task ShowAsync(INavigationWindowOptionsModel navigationWindowOptions, IPageViewNavigationOptions pageViewNavigationOptions)
    {
        INavigationWindow navigationWindow = GetNavigationWindow(navigationWindowOptions.WindowType);

        InitializeNavigationWindow((INavigationWindowViewModel)navigationWindow.DataContext,
                                   (INavigationWindowViewModelInitializerModel)navigationWindowOptions.WindowViewModelInitializerModel);

        Navigate((INavigationWindowViewModel)navigationWindow.DataContext, pageViewNavigationOptions);

        navigationWindow.Show();

        await Task.CompletedTask;
    }

    private INavigationWindow GetNavigationWindow(Type navigationWindowType)
    {
        return (INavigationWindow)_serviceProvider.GetRequiredService(navigationWindowType);
    }

    private void InitializeNavigationWindow(INavigationWindowViewModel navigationWindowViewModel, INavigationWindowViewModelInitializerModel navigationWindowViewModelInitializerModel)
    {
        Type navigationWindowViewModelType = navigationWindowViewModel.GetType();
        Type navigationWindowViewModelInitializerModelType = navigationWindowViewModelInitializerModel.GetType();

        Type navigationWindowViewModelInitializerType = typeof(INavigationWindowViewModelInitializer<,>)
            .MakeGenericType(navigationWindowViewModelType, navigationWindowViewModelInitializerModelType);

        MethodInfo navigationWindowViewModelInitializerInitializeMethodInfo = navigationWindowViewModelInitializerType
            .GetInterfaces()
            .Single()
            .GetMethods()
            .Single();

        object navigationWindowViewModelInitializer =
            _serviceProvider.GetRequiredService(navigationWindowViewModelInitializerType);

        navigationWindowViewModelInitializerInitializeMethodInfo
            .Invoke(navigationWindowViewModelInitializer, new object[] { navigationWindowViewModel, navigationWindowViewModelInitializerModel });
    }

    private static void Navigate(INavigationWindowViewModel navigationWindowViewModel, IPageViewNavigationOptions pageViewNavigationOptions)
    { 
        navigationWindowViewModel.CurrentNavigationWindowService.Navigate(pageViewNavigationOptions);
    }
}