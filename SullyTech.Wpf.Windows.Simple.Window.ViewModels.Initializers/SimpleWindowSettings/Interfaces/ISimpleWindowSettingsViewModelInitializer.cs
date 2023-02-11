using SullyTech.Wpf.Windows.Core.Window.ViewModels.Initializers.WindowSettings.Interfaces;
using SullyTech.Wpf.Windows.Simple.Window.ViewModels.Initializers.SimpleWindowSettings.Models.Interfaces;
using SullyTech.Wpf.Windows.Simple.Window.ViewModels.Interfaces.SimpleWindowSettings;

namespace SullyTech.Wpf.Windows.Simple.Window.ViewModels.Initializers.SimpleWindowSettings.Interfaces;

public interface ISimpleWindowSettingsViewModelInitializer<in TISimpleWindowSettingsViewModel, in TISimpleWindowSettingsViewModelInitializerModel> :
    IWindowSettingsViewModelInitializer<TISimpleWindowSettingsViewModel, TISimpleWindowSettingsViewModelInitializerModel>
        where TISimpleWindowSettingsViewModel : ISimpleWindowSettingsViewModel
        where TISimpleWindowSettingsViewModelInitializerModel : ISimpleWindowSettingsViewModelInitializerModel
{ }
