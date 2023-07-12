using SullyTech.Wpf.Dialogs.Exception.Window.Result.Enums;
using SullyTech.Wpf.Dialogs.Exception.Window.Result.Interfaces;

namespace SullyTech.Wpf.Dialogs.Exception.Window.Result;

public sealed class ExceptionDialogResult : IExceptionDialogResult
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