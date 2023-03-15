using SullyTech.Cqrs.Command.Contracts.Interfaces.Response;
using SullyTech.Cqrs.Command.Contracts.Result.Interfaces;

namespace SullyTech.Cqrs.Command.Contracts.Result;

public readonly struct CommandResult : ICommandResult
{
    public bool IsSuccessFul { get; }

    public string? ErrorMessage { get; }

    internal CommandResult(bool isSuccessFul, string? errorMessage = null)
    {
        IsSuccessFul = isSuccessFul;
        ErrorMessage = errorMessage;
    }

    public static CommandResult Success()
    {
        return new CommandResult(true);
    }

    public static CommandResult Error(string errorMessage)
    {
        Guard.Guard.ThrowIfNullOrWhitespace(errorMessage, nameof(errorMessage));

        return new CommandResult(false, errorMessage);
    }
}

public readonly struct CommandResult<TCommandResponseModel> : ICommandResult
    where TCommandResponseModel : ICommandResponseModel
{
    public bool IsSuccessFul { get; }

    public string? ErrorMessage { get; }

    private readonly TCommandResponseModel? _value;
    public TCommandResponseModel Value
    {
        get
        {
            if (!IsSuccessFul)
            {
                throw new InvalidOperationException(
                    "The command value reading is not allowed, because the command was not executed successfully!");
            }

            if (IsSuccessFul && _value is null)
            {
                throw new InvalidOperationException(
                    "The command value reading is not allowed, because the command executed successfully, however the adjusted value is null!");
            }

            return _value!;
        }
    }

    internal CommandResult(bool isSuccessFul, TCommandResponseModel? value = default, string? message = null)
    {
        _value = value;
        ErrorMessage = message;
        IsSuccessFul = isSuccessFul;
    }

    public static CommandResult<TCommandResponseModel> Success(TCommandResponseModel resultValue)
    {
        Guard.Guard.ThrowIfNull(resultValue, nameof(resultValue));

        return new CommandResult<TCommandResponseModel>(true, resultValue);
    }

    public static CommandResult Error(string message)
    {
        Guard.Guard.ThrowIfNullOrWhitespace(message, nameof(message));

        return new CommandResult(false, errorMessage: message);
    }
}