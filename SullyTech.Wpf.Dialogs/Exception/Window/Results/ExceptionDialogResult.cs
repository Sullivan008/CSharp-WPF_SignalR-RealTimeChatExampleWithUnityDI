using SullyTech.Wpf.Controls.Window.Dialog.Core.Results;
using SullyTech.Wpf.Dialogs.Exception.Window.Results.Enums;

namespace SullyTech.Wpf.Dialogs.Exception.Window.Results;

public record ExceptionDialogResult : DialogResult
{
    public required ResultType ResultType { get; init; }
}