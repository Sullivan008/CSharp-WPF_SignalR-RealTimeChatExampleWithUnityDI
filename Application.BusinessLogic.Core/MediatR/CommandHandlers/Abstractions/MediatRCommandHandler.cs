using Application.BusinessLogic.Core.MediatR.Commands.Abstractions;
using MediatR;

namespace Application.BusinessLogic.Core.MediatR.CommandHandlers.Abstractions;

public abstract class MediatRCommandHandler<TMediatRCommand> : IRequestHandler<TMediatRCommand>
    where TMediatRCommand : MediatRCommand
{
    public abstract Task<Unit> Handle(TMediatRCommand request, CancellationToken cancellationToken);
}