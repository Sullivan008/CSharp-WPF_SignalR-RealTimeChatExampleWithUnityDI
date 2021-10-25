using Application.Hub.Chat.Interfaces;

namespace Application.Hub.Chat
{
    public class ChatHub : Microsoft.AspNetCore.SignalR.Hub<IChatHub>
    { }
}
