using Application.Web.SignalR.Core.Hubs.Contracts.Models.ResponseModels;
using Application.Web.SignalR.Hubs.Contracts.ChatHub.Models.GetConnectedUsers.ResponseModel.SubModels;

namespace Application.Web.SignalR.Hubs.Contracts.ChatHub.Models.GetConnectedUsers.ResponseModel;

public class GetConnectedUsersResponseModel : SignalRResponseModel
{
    public IReadOnlyCollection<ConnectedUserResponseModel> ConnectedUsers { get; init; } = new List<ConnectedUserResponseModel>();
}