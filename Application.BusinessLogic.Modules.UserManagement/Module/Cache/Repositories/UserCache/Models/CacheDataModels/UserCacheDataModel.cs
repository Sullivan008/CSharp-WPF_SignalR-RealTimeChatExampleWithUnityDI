using Application.Cache.Core.Models.CacheData.Interfaces;
using SullyTech.Guard;

namespace Application.BusinessLogic.Modules.UserManagement.Module.Cache.Repositories.UserCache.Models.CacheDataModels;

public class UserCacheDataModel : ICacheDataModel
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