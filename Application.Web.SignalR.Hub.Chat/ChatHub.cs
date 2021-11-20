using Application.Web.SignalR.Hub.Chat.Interfaces;

namespace Application.Web.Hub.Chat;

public class ChatHub : Microsoft.AspNetCore.SignalR.Hub<IChatHub>
{ }