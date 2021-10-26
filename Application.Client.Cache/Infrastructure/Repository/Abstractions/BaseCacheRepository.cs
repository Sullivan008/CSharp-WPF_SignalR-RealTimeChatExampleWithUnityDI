using Application.Client.Cache.Infrastructure.Enums;
using Application.Client.Cache.Infrastructure.Models.Interfaces;
using Application.Client.Cache.Infrastructure.Models.Options;
using Application.Client.Cache.Infrastructure.Services.Interfaces;

namespace Application.Client.Cache.Infrastructure.Repository.Abstractions
{
    public abstract class BaseCacheRepository<TCacheDataModel> where TCacheDataModel : ICacheDataModel
    {
        private readonly IApplicationCacheService _applicationCacheService;

        protected BaseCacheRepository(IApplicationCacheService applicationCacheService)
        {
            _applicationCacheService = applicationCacheService;
        }

        public TCacheDataModel GetItem()
        {
            return _applicationCacheService.GetItem<TCacheDataModel>(GetCacheKey());
        }

        public void SetItem(TCacheDataModel dataItem)
        {
            CacheSaveOptions<TCacheDataModel> saveOptions = new()
            {
                Key = GetCacheKey(),
                Data = dataItem
            };

            _applicationCacheService.SetItem(saveOptions);
        }

        protected abstract CacheKey GetCacheKey();
    }
}
