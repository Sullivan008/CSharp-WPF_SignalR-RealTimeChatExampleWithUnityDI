using Application.Web.SignalR.Core.Hubs.Interfaces;
using Application.Web.SignalR.Hubs.Contracts.ChatHub.Models.SignIn.RequestModels;

namespace Application.Web.SignalR.Hubs.Contracts.ChatHub.Interfaces;

public interface IChatHub : ISignalRHub
{
    public Task SignIn(SignInRequestModel signalRRequestModel);
}