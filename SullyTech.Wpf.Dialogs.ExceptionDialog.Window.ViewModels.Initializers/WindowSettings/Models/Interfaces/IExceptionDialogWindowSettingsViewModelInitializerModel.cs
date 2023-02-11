using SullyTech.Wpf.Windows.Dialog.Window.ViewModels.Initializers.DialogWindowSettings.Models.Interfaces;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;

public interface IExceptionDialogWindowSettingsViewModelInitializerModel : IDialogWindowSettingsViewModelInitializerModel
{
    public string Title { get; init; }
}