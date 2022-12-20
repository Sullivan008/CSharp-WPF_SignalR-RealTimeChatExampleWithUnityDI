using SullyTech.Wpf.Windows.Core.ViewModels.Initializers.WindowSettings.Interfaces;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindowSettings.Models.Interfaces;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Interfaces.DialogWindowSettings;

namespace SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindowSettings.Interfaces;

public interface IDialogWindowSettingsViewModelInitializer<in TIDialogWindowSettingsViewModel, in TIDialogWindowSettingsViewModelInitializerModel> :
    IWindowSettingsViewModelInitializer<TIDialogWindowSettingsViewModel, TIDialogWindowSettingsViewModelInitializerModel>
        where TIDialogWindowSettingsViewModel : IDialogWindowSettingsViewModel
        where TIDialogWindowSettingsViewModelInitializerModel : IDialogWindowSettingsViewModelInitializerModel
{ }