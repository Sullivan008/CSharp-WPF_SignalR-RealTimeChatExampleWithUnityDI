using SullyTech.Wpf.Dialogs.MessageDialog.Result.Enums;
using SullyTech.Wpf.Windows.Dialog.Result.Interfaces.DialogResult;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Result;

public sealed class MessageDialogResult : IDialogResult
{
    private readonly ResultType? _resultType;
    public ResultType ResultType
    {
        get
        {
            Guard.Guard.ThrowIfNull(_resultType, nameof(ResultType));

            return _resultType!.Value;
        }

        init => _resultType = value;
    }
}