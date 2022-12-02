using SullyTech.Wpf.Windows.Core.ViewModels.Initializers.WindowSettings.Interfaces;
using SullyTech.Wpf.Windows.Simple.ViewModels.Initializers.SimpleWindowSettings.Models.Interfaces;
using SullyTech.Wpf.Windows.Simple.ViewModels.Interfaces.SimpleWindowSettings;

namespace SullyTech.Wpf.Windows.Simple.ViewModels.Initializers.SimpleWindowSettings.Interfaces;

public interface ISimpleWindowSettingsViewModelInitializer<in TSimpleWindowSettingsViewModel, in TSimpleWindowSettingsViewModelInitializerModel> :
    IWindowSettingsViewModelInitializer<TSimpleWindowSettingsViewModel, TSimpleWindowSettingsViewModelInitializerModel>
        where TSimpleWindowSettingsViewModel : ISimpleWindowSettingsViewModel
        where TSimpleWindowSettingsViewModelInitializerModel : ISimpleWindowSettingsViewModelInitializerModel
{ }
