using Application.BusinessLogic.Core.MediatR.CommandHandlers.Abstractions;
using Application.BusinessLogic.Modules.UserManagement.Module.Services.User.Interfaces;
using Application.Web.SignalR.Hubs.Contracts.Implementations.ChatHub.Interfaces;
using Application.Web.SignalR.Hubs.Core.Abstractions;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace Application.BusinessLogic.Modules.UserManagement.Module.Commands.SignIn.Handler;

public class SignInCommandHandler : MediatRCommandHandler<SignInCommand>
{
    private readonly IUserService _userService;

    private readonly IHubContext<SignalRHub<IChatHub>, IChatHub> _hubContext;

    public SignInCommandHandler(IUserService userService, IHubContext<SignalRHub<IChatHub>, IChatHub> hubContext)
    {
        _userService = userService;
        _hubContext = hubContext;
    }

    public override async Task<Unit> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        return Unit.Value;
    }
}