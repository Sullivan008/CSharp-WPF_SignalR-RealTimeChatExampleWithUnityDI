using Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindowSettings.Initializer.Models;
using SullyTech.Wpf.Windows.Navigation.ViewModels.Initializers.NavigationWindowSettings.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindowSettings.Initializer;

internal class MainWindowSettingsViewModelInitializer : INavigationWindowSettingsViewModelInitializer<IMainWindowSettingsViewModel, IMainWindowSettingsViewModelInitializerModel>
{
    public void Initialize(IMainWindowSettingsViewModel windowSettingsViewModel, IMainWindowSettingsViewModelInitializerModel windowSettingsViewModelInitializerModel)
    {
        windowSettingsViewModel.Title = windowSettingsViewModelInitializerModel.Title;
        windowSettingsViewModel.Width = windowSettingsViewModelInitializerModel.Width;
        windowSettingsViewModel.Height = windowSettingsViewModelInitializerModel.Height;
    }
}