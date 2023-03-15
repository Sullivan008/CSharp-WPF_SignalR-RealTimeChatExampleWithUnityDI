using MediatR;
using SullyTech.Cqrs.Command.Contracts.Interfaces.Request;
using SullyTech.Cqrs.Command.Contracts.Result.Interfaces;

namespace SullyTech.Cqrs.Command.Handlers;

public abstract class CommandHandler<TCommand, TCommandResult> : IRequestHandler<TCommand,TCommandResult>
    where TCommand : Abstractions.Command<TCommandResult>
    where TCommandResult : ICommandResult
{
    public abstract Task<TCommandResult> Handle(TCommand request, CancellationToken cancellationToken);
}

public abstract class CommandHandler<TCommand, TCommandRequestModel, TCommandResult> : IRequestHandler<TCommand, TCommandResult>
    where TCommand : Abstractions.Command<TCommandRequestModel, TCommandResult>
    where TCommandResult : ICommandResult
    where TCommandRequestModel : ICommandRequestModel
{
    public abstract Task<TCommandResult> Handle(TCommand request, CancellationToken cancellationToken);
}