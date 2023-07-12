using App.Client.Wpf.Windows.Main.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;
using App.Client.Wpf.Windows.Main.Window.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Initializers.WindowSettings.Interfaces;

namespace App.Client.Wpf.Windows.Main.Window.ViewModels.Initializers.WindowSettings;

internal sealed class MainWindowSettingsViewModelInitializer : IStandardWindowSettingsViewModelInitializer<IMainWindowSettingsViewModel, IMainWindowSettingsViewModelInitializerModel>
{
    public void Initialize(IMainWindowSettingsViewModel windowSettingsViewModel, IMainWindowSettingsViewModelInitializerModel windowSettingsViewModelInitializerModel)
    {
        windowSettingsViewModel.Title = windowSettingsViewModelInitializerModel.Title;
        windowSettingsViewModel.Width = windowSettingsViewModelInitializerModel.Width;
        windowSettingsViewModel.Height = windowSettingsViewModelInitializerModel.Height;
    }
}