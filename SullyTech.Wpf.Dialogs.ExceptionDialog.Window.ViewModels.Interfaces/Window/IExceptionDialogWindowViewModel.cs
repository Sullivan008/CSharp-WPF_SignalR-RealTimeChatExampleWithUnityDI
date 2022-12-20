using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Interfaces.DialogWindow;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Interfaces.Window;

public interface IExceptionDialogWindowViewModel : IDialogWindowViewModel
{
    public new IExceptionDialogWindowSettingsViewModel Settings { get; }
}