using Application.BusinessLogic.Core.MediatR.QueryHandlers.Abstractions;
using Application.BusinessLogic.Modules.UserManagement.Module.Queries.GetConnectedUsers.ResponseModel;
using Application.BusinessLogic.Modules.UserManagement.Module.Queries.GetConnectedUsers.ResponseModel.SubModels;
using Application.BusinessLogic.Modules.UserManagement.Module.Services.User.Interfaces;
using Application.BusinessLogic.Modules.UserManagement.Module.Services.User.Models;

namespace Application.BusinessLogic.Modules.UserManagement.Module.Queries.GetConnectedUsers.Handler;

public class GetConnectedUsersQueryHandler : MediatRQueryHandler<GetConnectedUsersQuery, GetConnectedUsersResponseModel>
{
    private readonly IUserService _userService;

    public GetConnectedUsersQueryHandler(IUserService userService)
    {
        _userService = userService;
    }

    public override async Task<GetConnectedUsersResponseModel> Handle(GetConnectedUsersQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<UserModel> cachedUsers = _userService.GetUsers();

        GetConnectedUsersResponseModel result = new()
        {
            ConnectedUsers = cachedUsers.Select(x => new ConnectedUserResponseModel
            {
                NickName = x.NickName
            }).ToList()
        };

        return await Task.FromResult(result);
    }
}