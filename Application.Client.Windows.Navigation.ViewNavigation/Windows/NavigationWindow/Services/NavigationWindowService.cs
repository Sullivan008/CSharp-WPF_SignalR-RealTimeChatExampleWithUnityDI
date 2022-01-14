using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModelInitializers.PageViewModelInitializer.InitializerModels.Abstractions;
using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModelInitializers.PageViewModelInitializer.InitializerModels.Interfaces.Markers;
using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.PageViewModel.Interfaces.Markers;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.Abstractions.Options;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.Services.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.ViewModels.Abstractions;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.ViewModels.Initializers.Abstractions.Models;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.ViewModels.Initializers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.Services;

public class NavigationWindowService : INavigationWindowService
{
    private readonly IServiceProvider _serviceProvider;

    public NavigationWindowService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task ShowAsync<TNavigationWindow, TNavigationWindowViewModel, TNavigationWindowViewModelInitializerModel, TPageViewModel>(
        NavigationWindowOptions<TNavigationWindowViewModelInitializerModel> navigationWindowOptions) where TNavigationWindow : Abstractions.Window.NavigationWindow
                                                                                                     where TNavigationWindowViewModel : NavigationWindowViewModelBase
                                                                                                     where TNavigationWindowViewModelInitializerModel : BaseNavigationWindowViewModelInitializerModel
                                                                                                     where TPageViewModel : IPageViewModel
    {
        TNavigationWindow navigationWindow = GetNavigationWindow<TNavigationWindow>();

        InitializeNavigationWindow((TNavigationWindowViewModel)navigationWindow.DataContext, navigationWindowOptions.WindowViewModelInitializerModelFactory);
        Navigate<TNavigationWindow, TNavigationWindowViewModel, TPageViewModel>(navigationWindow);

        navigationWindow.Show();

        await Task.CompletedTask;
    }

    public async Task ShowAsync<TNavigationWindow, TNavigationWindowViewModel, TNavigationWindowViewModelInitializerModel, TPageViewModel, TPageViewModelInitializerModel>(
        NavigationWindowOptions<TNavigationWindowViewModelInitializerModel, TPageViewModelInitializerModel> navigationWindowOptions) where TNavigationWindow : Abstractions.Window.NavigationWindow
                                                                                                                                     where TNavigationWindowViewModel : NavigationWindowViewModelBase
                                                                                                                                     where TNavigationWindowViewModelInitializerModel : BaseNavigationWindowViewModelInitializerModel
                                                                                                                                     where TPageViewModel : IPageViewModel
                                                                                                                                     where TPageViewModelInitializerModel : IPageViewModelInitializerModel
    {
        TNavigationWindow navigationWindow = GetNavigationWindow<TNavigationWindow>();

        InitializeNavigationWindow((TNavigationWindowViewModel)navigationWindow.DataContext, navigationWindowOptions.WindowViewModelInitializerModelFactory);
        Navigate<TNavigationWindow, TNavigationWindowViewModel, TPageViewModel, TPageViewModelInitializerModel>(navigationWindow, navigationWindowOptions.PageViewModelInitializerFactory);
        
        navigationWindow.Show();

        await Task.CompletedTask;
    }


    private TNavigationWindow GetNavigationWindow<TNavigationWindow>() where TNavigationWindow : Abstractions.Window.NavigationWindow
    {
        return _serviceProvider.GetRequiredService<TNavigationWindow>();
    }

    private void InitializeNavigationWindow<TNavigationWindowViewModel, TNavigationWindowViewModelInitializerModel>(
        TNavigationWindowViewModel navigationWindowViewModel, Func<TNavigationWindowViewModelInitializerModel> navigationWindowViewModelInitializerModelFactory) where TNavigationWindowViewModel : NavigationWindowViewModelBase
                                                                                                                                                                 where TNavigationWindowViewModelInitializerModel : BaseNavigationWindowViewModelInitializerModel
    {
        INavigationWindowViewModelInitializer<TNavigationWindowViewModel, TNavigationWindowViewModelInitializerModel> navigationWindowViewModelInitializer = 
            _serviceProvider.GetRequiredService<INavigationWindowViewModelInitializer<TNavigationWindowViewModel, TNavigationWindowViewModelInitializerModel>>();

        TNavigationWindowViewModelInitializerModel navigationWindowViewModelInitializerModel = navigationWindowViewModelInitializerModelFactory();
        
        navigationWindowViewModelInitializer.Initialize(navigationWindowViewModel, navigationWindowViewModelInitializerModel);
    }

    private static void Navigate<TNavigationWindow, TNavigationWindowViewModel, TPageViewModel>(TNavigationWindow navigationWindow) where TNavigationWindow : Abstractions.Window.NavigationWindow
                                                                                                                                    where TNavigationWindowViewModel : NavigationWindowViewModelBase
                                                                                                                                    where TPageViewModel : IPageViewModel
    {
        ((TNavigationWindowViewModel)navigationWindow.DataContext).Navigate<TPageViewModel>();
    }

    private static void Navigate<TNavigationWindow, TNavigationWindowViewModel, TPageViewModel, TPageViewModelInitializerModel>(
        TNavigationWindow navigationWindow, Func<TPageViewModelInitializerModel> pageViewModelInitializerModelFactory) where TNavigationWindow : Abstractions.Window.NavigationWindow
                                                                                                                       where TNavigationWindowViewModel : NavigationWindowViewModelBase
                                                                                                                       where TPageViewModel : IPageViewModel
                                                                                                                       where TPageViewModelInitializerModel : IPageViewModelInitializerModel
    {
        ((TNavigationWindowViewModel)navigationWindow.DataContext).Navigate<TPageViewModel, TPageViewModelInitializerModel>(pageViewModelInitializerModelFactory);
    }
}