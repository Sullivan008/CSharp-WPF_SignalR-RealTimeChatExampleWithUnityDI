using Application.Web.SignalR.Hubs.Contracts.ChatHub.Models.GetConnectedUsers.ResponseModel;
using Application.Web.SignalR.Hubs.Contracts.ChatHub.Models.SignIn.RequestModels;
using SullyTech.SignalR.Client.Core.Hub.Interfaces;

namespace SullyTech.App.Client.SignalR.Hubs.ChatHub.Interfaces;

public interface IChatHub : ISignalRHub
{
    public Task SignInAsync(SignInRequestModel requestModel);

    public Task<GetConnectedUsersResponseModel> GetConnectedUsersAsync();
}