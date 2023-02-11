using SullyTech.App.Client.Wpf.Windows.Main.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;
using SullyTech.App.Client.Wpf.Windows.Main.Window.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Windows.Navigation.Window.ViewModels.Initializers.NavigationWindowSettings.Interfaces;

namespace SullyTech.App.Client.Wpf.Windows.Main.Window.ViewModels.Initializers.WindowSettings;

internal sealed class MainWindowSettingsViewModelInitializer : INavigationWindowSettingsViewModelInitializer<IMainWindowSettingsViewModel, IMainWindowSettingsViewModelInitializerModel>
{
    public void Initialize(IMainWindowSettingsViewModel windowSettingsViewModel, IMainWindowSettingsViewModelInitializerModel windowSettingsViewModelInitializerModel)
    {
        windowSettingsViewModel.Title = windowSettingsViewModelInitializerModel.Title;
        windowSettingsViewModel.Width = windowSettingsViewModelInitializerModel.Width;
        windowSettingsViewModel.Height = windowSettingsViewModelInitializerModel.Height;
    }
}