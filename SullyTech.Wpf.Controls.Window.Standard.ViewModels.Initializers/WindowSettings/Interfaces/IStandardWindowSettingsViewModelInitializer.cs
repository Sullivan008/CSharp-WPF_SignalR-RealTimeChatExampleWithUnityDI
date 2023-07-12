using SullyTech.Wpf.Controls.Window.Core.ViewModels.Initializers.WindowSettings.Interfaces;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Initializers.WindowSettings.Models.Interfaces;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Controls.Window.Standard.ViewModels.Initializers.WindowSettings.Interfaces;

public interface IStandardWindowSettingsViewModelInitializer<in TIStandardWindowSettingsViewModel, in TIStandardWindowSettingsViewModelInitializerModel> :
    IWindowSettingsViewModelInitializer<TIStandardWindowSettingsViewModel, TIStandardWindowSettingsViewModelInitializerModel>
        where TIStandardWindowSettingsViewModel : IStandardWindowSettingsViewModel
        where TIStandardWindowSettingsViewModelInitializerModel : IStandardWindowSettingsViewModelInitializerModel
{ }
