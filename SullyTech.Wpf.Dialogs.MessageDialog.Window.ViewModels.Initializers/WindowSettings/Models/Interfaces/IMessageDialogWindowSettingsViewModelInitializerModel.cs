using SullyTech.Wpf.Windows.Dialog.Window.ViewModels.Initializers.DialogWindowSettings.Models.Interfaces;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;

public interface IMessageDialogWindowSettingsViewModelInitializerModel : IDialogWindowSettingsViewModelInitializerModel
{
    public string Title { get; init; }
}