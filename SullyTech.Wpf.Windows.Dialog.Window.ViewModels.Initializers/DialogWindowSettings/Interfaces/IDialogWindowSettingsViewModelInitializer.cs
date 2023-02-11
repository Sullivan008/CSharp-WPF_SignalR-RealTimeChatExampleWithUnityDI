using SullyTech.Wpf.Windows.Core.Window.ViewModels.Initializers.WindowSettings.Interfaces;
using SullyTech.Wpf.Windows.Dialog.Window.ViewModels.Initializers.DialogWindowSettings.Models.Interfaces;
using SullyTech.Wpf.Windows.Dialog.Window.ViewModels.Interfaces.DialogWindowSettings;

namespace SullyTech.Wpf.Windows.Dialog.Window.ViewModels.Initializers.DialogWindowSettings.Interfaces;

public interface IDialogWindowSettingsViewModelInitializer<in TIDialogWindowSettingsViewModel, in TIDialogWindowSettingsViewModelInitializerModel> :
    IWindowSettingsViewModelInitializer<TIDialogWindowSettingsViewModel, TIDialogWindowSettingsViewModelInitializerModel>
        where TIDialogWindowSettingsViewModel : IDialogWindowSettingsViewModel
        where TIDialogWindowSettingsViewModelInitializerModel : IDialogWindowSettingsViewModelInitializerModel
{ }