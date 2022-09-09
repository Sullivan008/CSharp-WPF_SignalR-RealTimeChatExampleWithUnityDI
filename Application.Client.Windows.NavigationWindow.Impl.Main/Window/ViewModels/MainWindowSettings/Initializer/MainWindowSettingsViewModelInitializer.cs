using Application.Client.Windows.NavigationWindow.Core.ViewModels.NavigationWindowSettings.Initializers.Interfaces;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindowSettings.Initializer.Models;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindowSettings.Initializer;

public class MainWindowSettingsViewModelInitializer : INavigationWindowSettingsViewModelInitializer<MainWindowSettingsViewModel, MainWindowSettingsViewModelInitializerModel>
{
    public void Initialize(MainWindowSettingsViewModel windowSettingsViewModel, MainWindowSettingsViewModelInitializerModel windowSettingsViewModelInitializerModel)
    {
        windowSettingsViewModel.Title = windowSettingsViewModelInitializerModel.Title;
        windowSettingsViewModel.Width = windowSettingsViewModelInitializerModel.Width;
        windowSettingsViewModel.Height = windowSettingsViewModelInitializerModel.Height;
    }
}