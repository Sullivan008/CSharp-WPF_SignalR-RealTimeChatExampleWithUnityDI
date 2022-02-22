using Application.Web.SignalR.Hubs.Core.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Application.Web.SignalR.Hubs.Core.Abstractions;

public abstract class SignalRHub<TSignalRHub> : Hub<TSignalRHub> where TSignalRHub : class, ISignalRHub
{
    public abstract override Task OnConnectedAsync();

    public abstract override Task OnDisconnectedAsync(Exception exception);
}