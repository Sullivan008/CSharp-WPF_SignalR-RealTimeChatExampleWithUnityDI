using Application.Common.Cache.Infrastructure.Repository.Abstractions;
using Application.Common.Cache.Infrastructure.Repository.Interfaces;
using Application.Common.Cache.Infrastructure.Services.Interfaces;
using Application.Web.Cache.DataModels.ChatHub.Participants;
using Application.Web.Cache.Enums.Keys;

namespace Application.Web.Cache.Repositories;

public class ChatHubCacheRepository : BaseCacheRepository<ChatHubCacheKeys, Participants>, ICacheRepository<ChatHubCacheKeys, Participants>
{
    public ChatHubCacheRepository(IApplicationCacheService applicationCacheService) : base(applicationCacheService)
    { }

    protected override ChatHubCacheKeys GetCacheKey()
    {
        return ChatHubCacheKeys.Participants;
    }
}