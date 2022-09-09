using Application.BusinessLogic.Core.MediatR.Queries.Abstractions;
using Application.BusinessLogic.Modules.UserManagement.Module.Queries.GetConnectedUsers.ResponseModel;

namespace Application.BusinessLogic.Modules.UserManagement.Module.Queries.GetConnectedUsers;

public class GetConnectedUsersQuery : MediatRQuery<GetConnectedUsersResponseModel>
{ }