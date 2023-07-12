using SullyTech.Wpf.Controls.Window.Dialog.Result.Interfaces;
using SullyTech.Wpf.Dialogs.Exception.Window.Result.Enums;

namespace SullyTech.Wpf.Dialogs.Exception.Window.Result.Interfaces;

public interface IExceptionDialogResult : IDialogResult
{
    public ResultType ResultType { get; init; }
} 