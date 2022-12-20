using SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindowSettings.Models.Interfaces;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;

internal interface IExceptionDialogWindowSettingsViewModelInitializerModel : IDialogWindowSettingsViewModelInitializerModel
{
    public string Title { get; init; }
}