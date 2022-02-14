using Application.Client.Windows.DialogWindow.ViewModels.DialogWindow;
using Application.Client.Windows.Implementations.ExceptionDialog.Window.ViewModels.ExceptionDialogWindow.Commands;
using Application.Client.Windows.Implementations.ExceptionDialog.Window.ViewModels.ExceptionDialogWindowSettings;
using Application.Client.Windows.Implementations.ExceptionDialog.Window.WindowResults.ExceptionDialog;

namespace Application.Client.Windows.Implementations.ExceptionDialog.Window.ViewModels.ExceptionDialogWindow;

public class ExceptionDialogWindowViewModel : DialogWindowViewModel<ExceptionDialogWindowSettingsViewModel, ExceptionDialogWindowResult>
{
    public ExceptionDialogWindowViewModel()
    {
        CloseWindowCommand = new CloseWindowCommand(this);
    }
}