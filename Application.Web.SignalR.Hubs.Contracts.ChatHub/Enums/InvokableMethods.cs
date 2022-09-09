using System.Runtime.Serialization;

namespace Application.Web.SignalR.Hubs.Contracts.ChatHub.Enums;

public enum InvokableMethods
{
    [EnumMember(Value = $"{nameof(SignIn)}")]
    SignIn = 1,

    [EnumMember(Value = $"{nameof(GetConnectedUsers)}")]
    GetConnectedUsers = 2
}