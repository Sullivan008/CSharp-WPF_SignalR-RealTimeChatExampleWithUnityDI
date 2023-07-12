using SullyTech.Wpf.Controls.Window.Dialog.Result.Interfaces;
using SullyTech.Wpf.Dialogs.Message.Window.Result.Enums;

namespace SullyTech.Wpf.Dialogs.Message.Window.Result.Interfaces;

public interface IMessageDialogResult : IDialogResult
{
    public ResultType ResultType { get; init; }
}