﻿using SullyTech.Wpf.Windows.Core.Window.Interfaces;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Windows.Core.Window.Services.Window.Abstractions;
using SullyTech.Wpf.Windows.Core.Window.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Window.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Window.Services.NavigationWindow.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Window.Services.NavigationWindow.MethodParameters.NavigateToOptions.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Window.Services.NavigationWindow.MethodParameters.WindowShowOptions.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Window.ViewModels.Initializers.NavigationWindow.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Window.ViewModels.Initializers.NavigationWindowSettings.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Window.ViewModels.Interfaces.NavigationWindow;

namespace SullyTech.Wpf.Windows.Navigation.Window.Services.NavigationWindow;

public sealed class NavigationWindowService : WindowService, INavigationWindowService
{
    public NavigationWindowService(IServiceProvider serviceProvider) : base(serviceProvider)
    { }

    public new async Task<INavigationWindow> GetWindowAsync(string windowId)
    {
        IWindow window = await base.GetWindowAsync(windowId);

        return (INavigationWindow)window;
    }

    public async Task ShowAsync(INavigationWindowShowOptions windowShowOptions, IPresenterLoadOptions presenterLoadOptions)
    {
        INavigationWindow window = (INavigationWindow)CreateWindow(windowShowOptions.WindowType);
        INavigationWindowViewModel windowViewModel = (INavigationWindowViewModel)CreateWindowViewModel(window, windowShowOptions.WindowViewModelType);

        InitializeWindowViewModel(windowViewModel, windowShowOptions.WindowViewModelType, windowShowOptions.WindowViewModelInitializerModel, windowShowOptions.WindowViewModelInitializerModelType);
        InitializeWindowSettingsViewModel(windowViewModel.Settings, windowShowOptions.WindowSettingsViewModelType, windowShowOptions.WindowSettingsViewModelInitializerModel, windowShowOptions.WindowSettingsViewModelInitializerModelType);

        IPresenterViewModel presenterViewModel =
            CreatePresenterViewModel(window, presenterLoadOptions.PresenterViewModelType);

        InitializePresenterViewModel(presenterViewModel, presenterLoadOptions.PresenterViewModelType,
            presenterLoadOptions.PresenterViewModelInitializerModel, presenterLoadOptions.PresenterViewModelInitializerModelType);

        InitializePresenterDataViewModel(presenterViewModel.Data, presenterLoadOptions.PresenterDataViewModelType,
            presenterLoadOptions.PresenterDataViewModelInitializerModel, presenterLoadOptions.PresenterDataViewModelInitializerModelType);

        SetWindowPresenter(windowViewModel, presenterViewModel);
        SetWindowDataContext(window, windowViewModel);

        window.Show();

        await OnInitWindowSettingsViewModel(windowViewModel.Settings);
        await OnInitWindowViewModel(windowViewModel);

        await OnInitPresenterDataViewModel(presenterViewModel.Data);
        await OnInitPresenterViewModel(presenterViewModel);

        await Task.CompletedTask;
    }

    public async Task NavigateToAsync(INavigationWindow window, INavigateToOptions navigateToOptions)
    {
        await OnDestroyPresenterDataViewModel(((INavigationWindowViewModel)window.DataContext).Presenter.Data);
        await OnDestroyPresenterViewModel(((INavigationWindowViewModel)window.DataContext).Presenter);

        IPresenterViewModel presenterViewModel = CreatePresenterViewModel(window, navigateToOptions.PresenterViewModelType);

        InitializePresenterViewModel(presenterViewModel, navigateToOptions.PresenterViewModelType,
            navigateToOptions.PresenterViewModelInitializerModel, navigateToOptions.PresenterViewModelInitializerModelType);

        InitializePresenterDataViewModel(presenterViewModel.Data, navigateToOptions.PresenterDataViewModelType,
            navigateToOptions.PresenterDataViewModelInitializerModel, navigateToOptions.PresenterDataViewModelInitializerModelType);

        await OnInitPresenterDataViewModel(presenterViewModel.Data);
        await OnInitPresenterViewModel(presenterViewModel);

        SetWindowPresenter((INavigationWindowViewModel)window.DataContext, presenterViewModel);

        await Task.CompletedTask;
    }

    protected override Type WindowViewModelInitializerGenericType => typeof(INavigationWindowViewModelInitializer<,>);

    protected override Type WindowSettingsViewModelInitializerGenericType => typeof(INavigationWindowSettingsViewModelInitializer<,>);
}