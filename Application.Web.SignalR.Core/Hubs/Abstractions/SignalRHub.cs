using Application.Web.SignalR.Core.Hubs.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Application.Web.SignalR.Core.Hubs.Abstractions;

public abstract class SignalRHub<TSignalRHub> : Hub<TSignalRHub> 
    where TSignalRHub : class, ISignalRHub
{
    public abstract override Task OnConnectedAsync();

    public abstract override Task OnDisconnectedAsync(Exception exception);
}