using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Result.Enums;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Result.Interfaces;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Result;

public sealed class ExceptionDialogResult : IExceptionDialogResult
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