using Application.Common.Cache.Infrastructure.Models.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Web.SignalR.Cache.DataModels.ChatHub.Participants;

public class Participant : ICacheDataModel
{
    private string? _connectionId;
    public string ConnectionId
    {
        get
        {
            Guard.ThrowIfNullOrWhitespace(_connectionId, nameof(ConnectionId));

            return _connectionId!;
        }
        set => _connectionId = value;
    }

    private string? _nickName;
    public string NickName
    {
        get
        {
            Guard.ThrowIfNullOrWhitespace(_nickName, nameof(NickName));

            return _nickName!;
        }
        set => _nickName = value;
    }
}