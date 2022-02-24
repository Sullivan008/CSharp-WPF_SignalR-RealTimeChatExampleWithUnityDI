using Application.BusinessLogic.Core.MediatR.CommandHandlers.Abstractions;
using Application.BusinessLogic.Modules.UserManagement.Module.Commands.SignIn.Exceptions;
using Application.BusinessLogic.Modules.UserManagement.Module.Commands.SignIn.RequestModel;
using Application.BusinessLogic.Modules.UserManagement.Module.Services.User.Interfaces;
using Application.BusinessLogic.Modules.UserManagement.Module.Services.User.Models;
using Application.Web.SignalR.Core.Hubs.Abstractions;
using Application.Web.SignalR.Hubs.Contracts.ChatHub.Interfaces;
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
        Validate(request.RequestModel);

        string nickName = GetNickName(request.RequestModel.NickName);

        _userService.AddUser(new UserModel
        {
            NickName = nickName,
            ConnectionId = request.RequestModel.CallerHubConnectionId
        });

        return await Task.FromResult(Unit.Value);
    }

    private void Validate(SignInCommandRequestModel requestModel)
    {
        ValidateConnectionId(requestModel.CallerHubConnectionId);
    }

    private void ValidateConnectionId(string connectionId)
    {
        IReadOnlySet<string> cachedConnectionIds = GetCachedConnectionIds();

        if (IsCachedConnectionId(cachedConnectionIds, connectionId))
        {
            throw new IsCachedConnectionIdException($"The following connection id is already cached for a user! {nameof(connectionId)}: {connectionId}");
        }
    }

    private string GetNickName(string inputNickName)
    {
        IReadOnlySet<string> cachedNickNames = GetCachedNickNames();

        string result = inputNickName;

        while (IsExistingNickName(cachedNickNames, result))
        {
            result = GenerateNickName(inputNickName);
        }

        return result;
    }

    private IReadOnlySet<string> GetCachedConnectionIds()
    {
        return _userService.GetUsers()
                           .Select(x => x.ConnectionId)
                           .ToHashSet();
    }

    private IReadOnlySet<string> GetCachedNickNames()
    {
        return _userService.GetUsers()
                           .Select(x => x.NickName)
                           .ToHashSet();
    }

    private static bool IsCachedConnectionId(IReadOnlySet<string> cachedConnectionIds, string connectionId)
    {
        return cachedConnectionIds.Contains(connectionId);
    }

    private static bool IsExistingNickName(IReadOnlySet<string> cachedNickNames, string nickName)
    {
        return cachedNickNames.Contains(nickName);
    }
    
    private static string GenerateNickName(string nickName)
    {
        return $"{nickName}{new Random().Next(1000000, 9999999)}";
    }
}