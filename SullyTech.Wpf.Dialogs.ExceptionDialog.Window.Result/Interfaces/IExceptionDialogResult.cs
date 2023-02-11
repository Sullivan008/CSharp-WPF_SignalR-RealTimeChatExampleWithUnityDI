using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Result.Enums;
using SullyTech.Wpf.Windows.Dialog.Window.Result.Interfaces;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Result.Interfaces;

public interface IExceptionDialogResult : IDialogResult
{
    public ResultType ResultType { get; init; }
} 