using Application.BusinessLogic.Core.MediatR.Queries.Models.ResponseModels.Interfaces;
using Application.BusinessLogic.Modules.UserManagement.Module.Queries.GetConnectedUsers.ResponseModel.SubModels;

namespace Application.BusinessLogic.Modules.UserManagement.Module.Queries.GetConnectedUsers.ResponseModel;

public class GetConnectedUsersResponseModel : IMediatRQueryResponseModel
{
    public IReadOnlyCollection<ConnectedUserResponseModel> ConnectedUsers { get; init; } = new List<ConnectedUserResponseModel>();
}