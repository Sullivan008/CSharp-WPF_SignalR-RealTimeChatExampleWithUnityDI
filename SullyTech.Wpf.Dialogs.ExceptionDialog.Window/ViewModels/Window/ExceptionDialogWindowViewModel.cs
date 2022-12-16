using SullyTech.Wpf.Dialogs.ExceptionDialog.Result;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Window.Commands;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.WindowSettings;
using SullyTech.Wpf.Windows.Dialog.ViewModels.DialogWindow;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Window;

public sealed class ExceptionDialogWindowViewModel : DialogWindowViewModel<ExceptionDialogWindowSettingsViewModel, ExceptionDialogResult>
{
    public ExceptionDialogWindowViewModel(ExceptionDialogWindowSettingsViewModel settings) : base(settings)
    {
        CloseWindowCommand = new CloseWindowCommand(this);
    }
}