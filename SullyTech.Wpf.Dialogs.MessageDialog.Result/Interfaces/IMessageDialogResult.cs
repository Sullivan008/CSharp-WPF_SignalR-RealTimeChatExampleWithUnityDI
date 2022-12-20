using SullyTech.Wpf.Dialogs.MessageDialog.Result.Enums;
using SullyTech.Wpf.Windows.Dialog.Result.Interfaces.DialogResult;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Result.Interfaces;

public interface IMessageDialogResult : IDialogResult
{
    public ResultType ResultType { get; init; }
}