using SullyTech.Wpf.Dialogs.Message.Window.Result.Enums;
using SullyTech.Wpf.Dialogs.Message.Window.Result.Interfaces;

namespace SullyTech.Wpf.Dialogs.Message.Window.Result;

public sealed class MessageDialogResult : IMessageDialogResult
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