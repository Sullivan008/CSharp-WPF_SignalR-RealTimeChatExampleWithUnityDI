using Application.Web.SignalR.Hub.ChatHub.Interfaces;

namespace Application.Web.SignalR.Hub.ChatHub;

public class ChatHub : Microsoft.AspNetCore.SignalR.Hub<IChatHub>
{ }