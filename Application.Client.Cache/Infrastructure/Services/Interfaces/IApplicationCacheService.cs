using Application.Client.Cache.Infrastructure.Enums;
using Application.Client.Cache.Infrastructure.Models.Interfaces;
using Application.Client.Cache.Infrastructure.Models.Options;

namespace Application.Client.Cache.Infrastructure.Services.Interfaces
{
    public interface IApplicationCacheService
    {
        TCacheDataModel GetItem<TCacheDataModel>(CacheKey key) where TCacheDataModel : ICacheDataModel;

        void SetItem<TCacheDataModel>(CacheSaveOptions<TCacheDataModel> saveOptions) where TCacheDataModel : ICacheDataModel;

        void RemoveItem(CacheKey key);

        void Clear();
    }
}
