using MediatR;
using SullyTech.Cqrs.Command.Contracts.Interfaces.Request;
using SullyTech.Cqrs.Command.Contracts.Result.Interfaces;

namespace SullyTech.Cqrs.Command.Abstractions;

public abstract class Command<TCommandResult> : IRequest<TCommandResult>
    where TCommandResult : ICommandResult
{ }

public abstract class Command<TCommandRequestModel, TCommandResult> : IRequest<TCommandResult>
    where TCommandResult : ICommandResult
    where TCommandRequestModel : ICommandRequestModel
{
    public TCommandRequestModel RequestModel { get; }

    protected Command(TCommandRequestModel requestModel)
    {
        Guard.Guard.ThrowIfNull(requestModel, nameof(RequestModel));

        RequestModel = requestModel;
    }
}