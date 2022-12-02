using SullyTech.Wpf.Windows.Core.ViewModels.Initializers.WindowSettings.Models.Interfaces;
using SullyTech.Wpf.Windows.Core.ViewModels.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Windows.Core.ViewModels.Initializers.WindowSettings.Interfaces;

public interface IWindowSettingsViewModelInitializer<in TWindowSettingsViewModel, in TWindowSettingsViewModelInitializerModel>
    where TWindowSettingsViewModel : IWindowSettingsViewModel
    where TWindowSettingsViewModelInitializerModel : IWindowSettingsViewModelInitializerModel
{
    public void Initialize(TWindowSettingsViewModel windowSettingsViewModel, TWindowSettingsViewModelInitializerModel windowSettingsViewModelInitializerModel);
}
