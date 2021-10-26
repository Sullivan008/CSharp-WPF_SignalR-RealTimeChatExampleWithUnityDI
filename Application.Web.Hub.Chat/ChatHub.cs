using Application.Web.Hub.Chat.Interfaces;

namespace Application.Web.Hub.Chat
{
    public class ChatHub : Microsoft.AspNetCore.SignalR.Hub<IChatHub>
    { }
}
