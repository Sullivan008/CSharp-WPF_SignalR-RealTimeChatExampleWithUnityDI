using SullyTech.Wpf.Windows.Core.Window.Interfaces;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Windows.Core.Window.Services.Window.Abstractions;
using SullyTech.Wpf.Windows.Core.Window.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions.Interfaces;
using SullyTech.Wpf.Windows.Simple.Window.Interfaces;
using SullyTech.Wpf.Windows.Simple.Window.Services.SimpleWindow.Interfaces;
using SullyTech.Wpf.Windows.Simple.Window.Services.SimpleWindow.MethodParameters.WindowShowOptions.Interfaces;
using SullyTech.Wpf.Windows.Simple.Window.ViewModels.Initializers.SimpleWindow.Interfaces;
using SullyTech.Wpf.Windows.Simple.Window.ViewModels.Initializers.SimpleWindowSettings.Interfaces;
using SullyTech.Wpf.Windows.Simple.Window.ViewModels.Interfaces.SimpleWindow;

namespace SullyTech.Wpf.Windows.Simple.Window.Services.SimpleWindow;

public sealed class SimpleWindowService : WindowService, ISimpleWindowService
{
    public SimpleWindowService(IServiceProvider serviceProvider) : base(serviceProvider)
    { }

    public new async Task<ISimpleWindow> GetWindowAsync(string windowId)
    {
        IWindow window = await base.GetWindowAsync(windowId);

        return (ISimpleWindow)window;
    }

    public async Task ShowAsync(ISimpleWindowShowOptions windowShowOptions, IPresenterLoadOptions presenterLoadOptions)
    {
        ISimpleWindow window = (ISimpleWindow)CreateWindow(windowShowOptions.WindowType);
        ISimpleWindowViewModel windowViewModel = (ISimpleWindowViewModel)CreateWindowViewModel(window, windowShowOptions.WindowViewModelType);

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
    
    protected override Type WindowViewModelInitializerGenericType => typeof(ISimpleWindowViewModelInitializer<,>);

    protected override Type WindowSettingsViewModelInitializerGenericType => typeof(ISimpleWindowSettingsViewModelInitializer<,>);
}