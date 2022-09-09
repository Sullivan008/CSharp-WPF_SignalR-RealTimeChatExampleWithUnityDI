using Application.Client.SignalR.Core.Hubs.Interfaces;
using Application.Web.SignalR.Hubs.Contracts.ChatHub.Models.GetConnectedUsers.ResponseModel;
using Application.Web.SignalR.Hubs.Contracts.ChatHub.Models.SignIn.RequestModels;

namespace Application.Client.SignalR.Hubs.ChatHub.Interfaces;

public interface IChatHub : ISignalRHub
{
    public Task SignInAsync(SignInRequestModel requestModel);

    public Task<GetConnectedUsersResponseModel> GetConnectedUsersAsync();
}