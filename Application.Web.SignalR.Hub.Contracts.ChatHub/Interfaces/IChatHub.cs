using Application.Web.SignalR.Hubs.Contracts.Implementations.ChatHub.Models.SignIn.RequestModels;
using Application.Web.SignalR.Hubs.Core.Interfaces;

namespace Application.Web.SignalR.Hubs.Contracts.Implementations.ChatHub.Interfaces;

public interface IChatHub : ISignalRHub
{
    public Task SignIn(SignInRequestModel signalRRequestModel);
}