using Application.Client.Windows.Implementations.Main.Window.ViewModels.MainWindow.Initializer.Models;
using Application.Client.Windows.Implementations.Main.Window.ViewModels.MainWindowSettings;
using Application.Client.Windows.Implementations.Main.Window.ViewModels.MainWindowSettings.Initializer.Models;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Initializers.Interfaces;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindowSettings.Initializers.Interfaces;

namespace Application.Client.Windows.Implementations.Main.Window.ViewModels.MainWindow.Initializer;

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