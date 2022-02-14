using Application.Client.Windows.DialogWindow.Models.CustomDialogWindowResult;
using Application.Client.Windows.Implementations.ExceptionDialog.Window.WindowResults.ExceptionDialog.Enums;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Implementations.ExceptionDialog.Window.WindowResults.ExceptionDialog;

public class ExceptionDialogWindowResult : CustomDialogWindowResult
{
    public readonly ExceptionDialogResult? _exceptionDialogResult;
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