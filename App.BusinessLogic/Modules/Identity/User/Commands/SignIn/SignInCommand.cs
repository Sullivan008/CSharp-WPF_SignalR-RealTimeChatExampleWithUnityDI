using SullyTech.Web.Api.Cqrs.Command.Handlers.Abstractions;
using SullyTech.Web.Api.Cqrs.Command.Interfaces;
using SullyTech.Web.Api.Cqrs.Core.Interfaces;

namespace App.BusinessLogic.Modules.Identity.User.Commands.SignIn;

public sealed record SignInCommand : ICommand
{
    public required string UserName { get; init; }

    public required string Password { get; init; }
}

public sealed class SignInCommandHandler : CommandHandler<SignInCommand>
{
    public override async Task<IResult> Handle(SignInCommand request, CancellationToken cancellationToken = default)
    {
        return Result.Success();
    }
}