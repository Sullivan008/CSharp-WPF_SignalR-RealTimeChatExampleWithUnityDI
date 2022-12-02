using Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.ViewModels.ExceptionDialogWindow.Commands;
using Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.ViewModels.ExceptionDialogWindowSettings;
using Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.WindowResults.ExceptionDialog;
using SullyTech.Wpf.Windows.Dialog.ViewModels.DialogWindow;

namespace Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.ViewModels.ExceptionDialogWindow;

public class ExceptionDialogWindowViewModel : DialogWindowViewModel<ExceptionDialogWindowSettingsViewModel, ExceptionDialogWindowResult>
{
    public ExceptionDialogWindowViewModel()
    {
        CloseWindowCommand = new CloseWindowCommand(this);
    }
}