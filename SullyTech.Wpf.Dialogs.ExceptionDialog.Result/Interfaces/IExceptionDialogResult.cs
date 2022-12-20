using SullyTech.Wpf.Dialogs.ExceptionDialog.Result.Enums;
using SullyTech.Wpf.Windows.Dialog.Result.Interfaces.DialogResult;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Result.Interfaces;

public interface IExceptionDialogResult : IDialogResult
{
    public ResultType ResultType { get; init; }
} 