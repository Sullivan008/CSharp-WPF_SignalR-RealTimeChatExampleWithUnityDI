using Application.Client.Windows.Implementations.Main.Window.ViewModels.MainWindow.Initializer.Models;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.ViewModels.Initializers.Interfaces;

namespace Application.Client.Windows.Implementations.Main.Window.ViewModels.MainWindow.Initializer;

public class MainWindowViewModelInitializer : INavigationWindowViewModelInitializer<MainWindowViewModel, MainWindowViewModelInitializerModel>
{
    public void Initialize(MainWindowViewModel navigationWindowViewModel, MainWindowViewModelInitializerModel navigationWindowViewModelInitializerModel)
    {
        InitializeWindowSettings((MainWindowSettingsViewModel)navigationWindowViewModel.WindowSettings,
                                 (MainWindowSettingsViewModelInitializerModel)navigationWindowViewModelInitializerModel.WindowSettings);
    }

    private static void InitializeWindowSettings(MainWindowSettingsViewModel settingsViewModel, MainWindowSettingsViewModelInitializerModel settingsViewModelInitializer)
    {
        settingsViewModel.Title = settingsViewModelInitializer.Title;
        settingsViewModel.Kefe = "Kefe";
    }
}