using Application.Client.Windows.NavigationWindow.Core.ViewModels.NavigationWindow.Initializers.Interfaces;
using Application.Client.Windows.NavigationWindow.Core.ViewModels.NavigationWindowSettings.Initializers.Interfaces;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindow.Initializer.Models;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindowSettings;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindowSettings.Initializer.Models;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindow.Initializer;

public class MainWindowViewModelInitializer : INavigationWindowViewModelInitializer<MainWindowViewModel, MainWindowViewModelInitializerModel>
{
    private readonly INavigationWindowSettingsViewModelInitializer<MainWindowSettingsViewModel, MainWindowSettingsViewModelInitializerModel> _windowSettingsViewModelInitializer;

    public MainWindowViewModelInitializer(INavigationWindowSettingsViewModelInitializer<MainWindowSettingsViewModel, MainWindowSettingsViewModelInitializerModel> windowSettingsViewModelInitializer)
    {
        _windowSettingsViewModelInitializer = windowSettingsViewModelInitializer;
    }

    public void Initialize(MainWindowViewModel windowViewModel, MainWindowViewModelInitializerModel windowViewModelInitializerModel)
    {
        _windowSettingsViewModelInitializer.Initialize(windowViewModel.WindowSettings, windowViewModelInitializerModel.WindowSettings);
    }
}