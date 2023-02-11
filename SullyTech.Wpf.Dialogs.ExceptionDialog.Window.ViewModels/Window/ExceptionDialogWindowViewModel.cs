using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Result.Interfaces;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Commands.Window;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Windows.Dialog.Window.ViewModels.DialogWindow;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Window;

public sealed class ExceptionDialogWindowViewModel : DialogWindowViewModel<IExceptionDialogWindowSettingsViewModel, IExceptionDialogResult>, IExceptionDialogWindowViewModel
{
    public ExceptionDialogWindowViewModel(IExceptionDialogWindowSettingsViewModel settings) : base(settings)
    {
        CloseWindowCommand = new CloseWindowCommand(this);
    }
}