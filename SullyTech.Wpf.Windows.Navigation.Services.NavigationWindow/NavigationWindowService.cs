using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Windows.Core.Services.Window.Abstractions;
using SullyTech.Wpf.Windows.Core.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Services.CurrentNavigationWindow.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow.Interfaces;
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

    public async Task ShowAsync(INavigationWindowShowOptions windowShowOptions, IPresenterLoadOptions presenterLoadOptions)
    {
        INavigationWindow window = (INavigationWindow)CreateWindow(windowShowOptions.WindowType);
        INavigationWindowViewModel windowViewModel = (INavigationWindowViewModel)CreateWindowViewModel(windowShowOptions.WindowViewModelType);

        InitializeWindowViewModel(windowViewModel, windowShowOptions.WindowViewModelInitializerModel);
        InitializeWindowSettingsViewModel(windowViewModel.Settings, windowShowOptions.WindowSettingsViewModelInitializerModel);

        ICurrentNavigationWindowService currentWindowService = (ICurrentNavigationWindowService)CreateCurrentWindowService(window);

        IPresenterViewModel presenterViewModel =
            CreatePresenterViewModel(presenterLoadOptions.PresenterViewModelType, currentWindowService);

        InitializePresenterViewModel(presenterViewModel, presenterLoadOptions.PresenterViewModelInitializerModel);
        InitializePresenterDataViewModel(presenterViewModel.Data, presenterLoadOptions.PresenterDataViewModelInitializerModel);

        SetWindowPresenter(windowViewModel, presenterViewModel);
        SetWindowDataContext(window, windowViewModel);

        window.Show();

        await Task.CompletedTask;
    }

    protected override Type CurrentWindowServiceType => typeof(ICurrentNavigationWindowService);

    protected override Type WindowViewModelInitializerGenericType => typeof(INavigationWindowViewModelInitializer<,>);

    protected override Type WindowSettingsViewModelInitializerGenericType => typeof(INavigationWindowSettingsViewModelInitializer<,>);
}