using SullyTech.Wpf.Controls.Window.Dialog.Core.Results;
using SullyTech.Wpf.Dialogs.Message.Window.Results.Enums;

namespace SullyTech.Wpf.Dialogs.Message.Window.Results;

public sealed record MessageDialogResult : DialogResult
{
    public required ResultType ResultType { get; init; }
}