using Application.Common.Cache.Infrastructure.Repository.Abstractions;
using Application.Common.Cache.Infrastructure.Repository.Interfaces;
using Application.Common.Cache.Infrastructure.Services.Interfaces;
using Application.Web.SignalR.Cache.DataModels.ChatHub.Participants;
using Application.Web.SignalR.Cache.Keys;

namespace Application.Web.SignalR.Cache.Repositories;

public class ChatHubCacheRepository : BaseCacheRepository<ChatHubCacheKeys, Participants>, ICacheRepository<ChatHubCacheKeys, Participants>
{
    public ChatHubCacheRepository(IApplicationCacheService applicationCacheService) : base(applicationCacheService)
    { }

    protected override ChatHubCacheKeys GetCacheKey()
    {
        return ChatHubCacheKeys.Participants;
    }
}