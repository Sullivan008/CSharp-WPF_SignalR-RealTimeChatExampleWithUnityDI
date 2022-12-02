using SullyTech.Wpf.Dialogs.ExceptionDialog.Result.Enums;
using SullyTech.Wpf.Windows.Dialog.Result.Interfaces.DialogResult;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Result;

public sealed class ExceptionDialogResult : IDialogResult
{
    private readonly ResultType? _resultType;
    public ResultType ResultType
    {
        get
        {
            Guard.Guard.ThrowIfNotNull(_resultType, nameof(ResultType));

            return _resultType!.Value;
        }

        init => _resultType = value;
    }
}