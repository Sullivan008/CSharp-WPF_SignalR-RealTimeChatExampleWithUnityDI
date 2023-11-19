using SullyTech.Wpf.Dialogs.Message.Window.Result.Enums;
using SullyTech.Wpf.Dialogs.Message.Window.Result.Interfaces;

namespace SullyTech.Wpf.Dialogs.Message.Window.Result;

public sealed class MessageDialogResult : IMessageDialogResult
{
    public required ResultType ResultType { get; init; }
}