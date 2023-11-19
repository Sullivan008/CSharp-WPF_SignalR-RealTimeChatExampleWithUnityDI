using SullyTech.Wpf.Dialogs.Exception.Window.Result.Enums;
using SullyTech.Wpf.Dialogs.Exception.Window.Result.Interfaces;

namespace SullyTech.Wpf.Dialogs.Exception.Window.Result;

public sealed class ExceptionDialogResult : IExceptionDialogResult
{
    public required ResultType ResultType { get; init; }
}