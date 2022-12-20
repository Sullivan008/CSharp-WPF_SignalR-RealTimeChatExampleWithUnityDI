using SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindowSettings.Models.Interfaces;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;

internal interface IMessageDialogWindowSettingsViewModelInitializerModel : IDialogWindowSettingsViewModelInitializerModel
{
    public string Title { get; init; }
}