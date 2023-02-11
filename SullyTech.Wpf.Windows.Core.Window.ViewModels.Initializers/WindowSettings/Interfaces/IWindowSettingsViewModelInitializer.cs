using SullyTech.Wpf.Windows.Core.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;
using SullyTech.Wpf.Windows.Core.Window.ViewModels.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Windows.Core.Window.ViewModels.Initializers.WindowSettings.Interfaces;

public interface IWindowSettingsViewModelInitializer<in TIWindowSettingsViewModel, in TIWindowSettingsViewModelInitializerModel>
    where TIWindowSettingsViewModel : IWindowSettingsViewModel
    where TIWindowSettingsViewModelInitializerModel : IWindowSettingsViewModelInitializerModel
{
    public void Initialize(TIWindowSettingsViewModel windowSettingsViewModel, TIWindowSettingsViewModelInitializerModel windowSettingsViewModelInitializerModel);
}
