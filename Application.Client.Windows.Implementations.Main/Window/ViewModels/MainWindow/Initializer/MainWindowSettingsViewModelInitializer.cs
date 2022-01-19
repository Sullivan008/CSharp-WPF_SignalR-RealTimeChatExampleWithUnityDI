using Application.Client.Windows.Implementations.Main.Window.ViewModels.MainWindow.Initializer.Models;
using Application.Client.Windows.Navigation.ViewNavigation.ViewModels.NavigationWindowSettings.Initializers.Interfaces;

namespace Application.Client.Windows.Implementations.Main.Window.ViewModels.MainWindow.Initializer;

public class MainWindowSettingsViewModelInitializer : INavigationWindowSettingsViewModelInitializer<MainWindowSettingsViewModel, MainWindowSettingsViewModelInitializerModel>
{
    public void Initialize(MainWindowSettingsViewModel navigationWindowSettingsViewModel,
                           MainWindowSettingsViewModelInitializerModel navigationWindowSettingsViewModelInitializerModel)
    {
        navigationWindowSettingsViewModel.Title = navigationWindowSettingsViewModelInitializerModel.Title;
        navigationWindowSettingsViewModel.Kefe = "Kefe";
    }
}