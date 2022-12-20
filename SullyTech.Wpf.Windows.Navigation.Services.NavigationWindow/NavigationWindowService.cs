using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Windows.Core.Services.Window.Abstractions;
using SullyTech.Wpf.Windows.Core.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions.Interfaces;
using SullyTech.Wpf.Windows.Core.Window.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow.MethodParameters.NavigateToOptions.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow.MethodParameters.WindowShowOptions.Interfaces;
using SullyTech.Wpf.Windows.Navigation.ViewModels.Initializers.NavigationWindow.Interfaces;
using SullyTech.Wpf.Windows.Navigation.ViewModels.Initializers.NavigationWindowSettings.Interfaces;
using SullyTech.Wpf.Windows.Navigation.ViewModels.Interfaces.NavigationWindow;
using SullyTech.Wpf.Windows.Navigation.Window.Interfaces;

namespace SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow;

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

        await Task.CompletedTask;
    }

    public async Task NavigateToAsync(INavigationWindow window, INavigateToOptions navigateToOptions)
    {
        IPresenterViewModel presenterViewModel = CreatePresenterViewModel(window, navigateToOptions.PresenterViewModelType);

        InitializePresenterViewModel(presenterViewModel, navigateToOptions.PresenterViewModelType,
            navigateToOptions.PresenterViewModelInitializerModel, navigateToOptions.PresenterViewModelInitializerModelType);

        InitializePresenterDataViewModel(presenterViewModel.Data, navigateToOptions.PresenterDataViewModelType,
            navigateToOptions.PresenterDataViewModelInitializerModel, navigateToOptions.PresenterDataViewModelInitializerModelType);


        SetWindowPresenter((INavigationWindowViewModel)window.DataContext, presenterViewModel);

        await Task.CompletedTask;
    }

    protected override Type WindowViewModelInitializerGenericType => typeof(INavigationWindowViewModelInitializer<,>);

    protected override Type WindowSettingsViewModelInitializerGenericType => typeof(INavigationWindowSettingsViewModelInitializer<,>);
}