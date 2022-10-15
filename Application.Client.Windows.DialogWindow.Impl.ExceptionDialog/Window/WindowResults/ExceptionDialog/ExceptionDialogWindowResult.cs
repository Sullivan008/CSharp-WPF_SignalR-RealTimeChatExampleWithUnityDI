using App.Core.Guard.Implementation;
using Application.Client.Windows.DialogWindow.Core.Models.CustomDialogWindowResult;
using Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.WindowResults.ExceptionDialog.Enums;

namespace Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.WindowResults.ExceptionDialog;

public class ExceptionDialogWindowResult : CustomDialogWindowResult
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