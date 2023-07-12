using SullyTech.Wpf.Controls.Window.Core.ViewModels.Initializers.WindowSettings.Interfaces;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Initializers.WindowSettings.Models.Interfaces;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Initializers.WindowSettings.Interfaces;

public interface IDialogWindowSettingsViewModelInitializer<in TIDialogWindowSettingsViewModel, in TIDialogWindowSettingsViewModelInitializerModel> :
    IWindowSettingsViewModelInitializer<TIDialogWindowSettingsViewModel, TIDialogWindowSettingsViewModelInitializerModel>
        where TIDialogWindowSettingsViewModel : IDialogWindowSettingsViewModel
        where TIDialogWindowSettingsViewModelInitializerModel : IDialogWindowSettingsViewModelInitializerModel
{ }