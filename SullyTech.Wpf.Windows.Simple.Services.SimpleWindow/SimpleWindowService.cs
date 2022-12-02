using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Windows.Core.Services.Window.Abstractions;
using SullyTech.Wpf.Windows.Core.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow.Interfaces;
using SullyTech.Wpf.Windows.Simple.Services.CurrentSimpleWindow.Interfaces;
using SullyTech.Wpf.Windows.Simple.Services.SimpleWindow.MethodParameters.WindowShowOptions.Interfaces;
using SullyTech.Wpf.Windows.Simple.ViewModels.Initializers.SimpleWindow.Interfaces;
using SullyTech.Wpf.Windows.Simple.ViewModels.Initializers.SimpleWindowSettings.Interfaces;
using SullyTech.Wpf.Windows.Simple.ViewModels.Interfaces.SimpleWindow;
using SullyTech.Wpf.Windows.Simple.Window.Interfaces;

namespace SullyTech.Wpf.Windows.Simple.Services.SimpleWindow;

public sealed class SimpleWindowService : WindowService, INavigationWindowService
{
    public SimpleWindowService(IServiceProvider serviceProvider) : base(serviceProvider)
    { }

    public async Task ShowAsync(ISimpleWindowShowOptions windowShowOptions, IPresenterLoadOptions presenterLoadOptions)
    {
        ISimpleWindow window = (ISimpleWindow)CreateWindow(windowShowOptions.WindowType);
        ISimpleWindowViewModel windowViewModel = (ISimpleWindowViewModel)CreateWindowViewModel(windowShowOptions.WindowViewModelType);

        InitializeWindowViewModel(windowViewModel, windowShowOptions.WindowViewModelInitializerModel);
        InitializeWindowSettingsViewModel(windowViewModel.Settings, windowShowOptions.WindowSettingsViewModelInitializerModel);

        ICurrentSimpleWindowService currentWindowService = (ICurrentSimpleWindowService)CreateCurrentWindowService(window);

        IPresenterViewModel presenterViewModel =
            CreatePresenterViewModel(presenterLoadOptions.PresenterViewModelType, currentWindowService);

        InitializePresenterViewModel(presenterViewModel, presenterLoadOptions.PresenterViewModelInitializerModel);
        InitializePresenterDataViewModel(presenterViewModel.Data, presenterLoadOptions.PresenterDataViewModelInitializerModel);

        SetWindowPresenter(windowViewModel, presenterViewModel);
        SetWindowDataContext(window, windowViewModel);

        window.Show();

        await Task.CompletedTask;
    }

    protected override Type CurrentWindowServiceType => typeof(ICurrentSimpleWindowService);

    protected override Type WindowViewModelInitializerGenericType => typeof(ISimpleWindowViewModelInitializer<,>);

    protected override Type WindowSettingsViewModelInitializerGenericType => typeof(ISimpleWindowSettingsViewModelInitializer<,>);
}