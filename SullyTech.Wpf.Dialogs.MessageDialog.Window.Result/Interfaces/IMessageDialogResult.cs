using SullyTech.Wpf.Dialogs.MessageDialog.Window.Result.Enums;
using SullyTech.Wpf.Windows.Dialog.Window.Result.Interfaces;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Window.Result.Interfaces;

public interface IMessageDialogResult : IDialogResult
{
    public ResultType ResultType { get; init; }
}