using MediatR;
using SullyTech.Web.Api.Cqrs.Command.Interfaces;
using SullyTech.Web.Api.Cqrs.Core;
using SullyTech.Web.Api.Cqrs.Core.Interfaces;

namespace SullyTech.Web.Api.Cqrs.Command.Handlers.Abstractions;

public abstract class CommandHandler<TCommand> : IRequestHandler<TCommand, IResult>
    where TCommand : ICommand
{
    protected readonly IResult Result = new Result();

    public abstract Task<IResult> Handle(TCommand request, CancellationToken cancellationToken = default);
}