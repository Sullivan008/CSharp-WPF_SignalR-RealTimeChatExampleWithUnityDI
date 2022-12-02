using Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.WindowResults.ExceptionDialog.Enums;
using SullyTech.Guard;
using SullyTech.Wpf.Windows.Dialog.Result.Interfaces.DialogResult;

namespace Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.WindowResults.ExceptionDialog;

public class ExceptionDialogWindowResult : IDialogResult
{
    private readonly ExceptionDialogResult? _exceptionDialogResult;
    public ExceptionDialogResult ExceptionDialogResult
    {
        get
        {
            Guard.ThrowIfNotNull(_exceptionDialogResult, nameof(ExceptionDialogResult));

            return _exceptionDialogResult!.Value;
        }

        init
        {
            Guard.ThrowIfNull(value, nameof(ExceptionDialogResult));

            _exceptionDialogResult = value;
        }
    }
}