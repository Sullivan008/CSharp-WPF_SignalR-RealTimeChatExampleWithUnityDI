using Application.Client.SignalR.Core.Hubs.Interfaces;
using Application.Web.SignalR.Hubs.Contracts.Implementations.ChatHub.Models.SignIn.RequestModels;

namespace Application.Client.SignalR.Hubs.ChatHub.Interfaces;

public interface IChatHub : ISignalRHub
{
    public Task SignInAsync(SignInRequestModel requestModel);
}