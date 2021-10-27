using Application.Web.Cache.DataModels.ChatHub;
using Application.Web.Cache.Infrastructure.Enums;
using Application.Web.Cache.Infrastructure.Repository.Abstractions;
using Application.Web.Cache.Infrastructure.Repository.Interfaces;
using Application.Web.Cache.Infrastructure.Services.Interfaces;

namespace Application.Web.Cache.Repositories
{
    public class ChatHubCacheRepository : BaseCacheRepository<ChatHubDataModel>, ICacheRepository<ChatHubDataModel>
    {
        public ChatHubCacheRepository(IApplicationCacheService applicationCacheService) : base(applicationCacheService)
        { }

        protected override CacheKey GetCacheKey()
        {
            return CacheKey.ChatHub;
        }
    }
}
