using SullyTech.Wpf.Windows.Core.ViewModels.Initializers.WindowSettings.Interfaces;
using SullyTech.Wpf.Windows.Simple.ViewModels.Initializers.SimpleWindowSettings.Models.Interfaces;
using SullyTech.Wpf.Windows.Simple.ViewModels.Interfaces.SimpleWindowSettings;

namespace SullyTech.Wpf.Windows.Simple.ViewModels.Initializers.SimpleWindowSettings.Interfaces;

public interface ISimpleWindowSettingsViewModelInitializer<in TISimpleWindowSettingsViewModel, in TISimpleWindowSettingsViewModelInitializerModel> :
    IWindowSettingsViewModelInitializer<TISimpleWindowSettingsViewModel, TISimpleWindowSettingsViewModelInitializerModel>
        where TISimpleWindowSettingsViewModel : ISimpleWindowSettingsViewModel
        where TISimpleWindowSettingsViewModelInitializerModel : ISimpleWindowSettingsViewModelInitializerModel
{ }
