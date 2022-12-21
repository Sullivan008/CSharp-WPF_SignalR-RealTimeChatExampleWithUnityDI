using SullyTech.App.Client.Wpf.Windows.Main.ViewModels.Initializers.WindowSettings.Models.Interfaces;
using SullyTech.App.Client.Wpf.Windows.Main.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Windows.Navigation.ViewModels.Initializers.NavigationWindowSettings.Interfaces;

namespace SullyTech.App.Client.Wpf.Windows.Main.ViewModels.Initializers.WindowSettings;

internal sealed class MainWindowSettingsViewModelInitializer : INavigationWindowSettingsViewModelInitializer<IMainWindowSettingsViewModel, IMainWindowSettingsViewModelInitializerModel>
{
    public void Initialize(IMainWindowSettingsViewModel windowSettingsViewModel, IMainWindowSettingsViewModelInitializerModel windowSettingsViewModelInitializerModel)
    {
        windowSettingsViewModel.Title = windowSettingsViewModelInitializerModel.Title;
        windowSettingsViewModel.Width = windowSettingsViewModelInitializerModel.Width;
        windowSettingsViewModel.Height = windowSettingsViewModelInitializerModel.Height;
    }
}