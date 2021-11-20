using System.Runtime.Serialization;

namespace Application.Web.SignalR.Cache.Keys;

public enum ChatHubCacheKeys
{
    [EnumMember(Value = "CHATHUB_PARTICIPANTS")]
    Participants
}