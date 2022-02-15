using Application.Client.Windows.Implementations.Main.Window.ViewModels.MainWindowSettings.Initializer.Models;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindowSettings.Initializers.Interfaces;

namespace Application.Client.Windows.Implementations.Main.Window.ViewModels.MainWindowSettings.Initializer;

public class MainWindowSettingsViewModelInitializer : INavigationWindowSettingsViewModelInitializer<MainWindowSettingsViewModel, MainWindowSettingsViewModelInitializerModel>
{
    public void Initialize(MainWindowSettingsViewModel windowSettingsViewModel, MainWindowSettingsViewModelInitializerModel windowSettingsViewModelInitializerModel)
    {
        windowSettingsViewModel.Title = windowSettingsViewModelInitializerModel.Title;
    }
}