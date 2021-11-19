using Application.Web.Cache.Infrastructure.Enums;
using Application.Web.Cache.Infrastructure.Models.Interfaces;
using Application.Web.Cache.Infrastructure.Models.Options;

namespace Application.Web.Cache.Infrastructure.Services.Interfaces;

public interface IApplicationCacheService
{
    TCacheDataModel GetItem<TCacheDataModel>(CacheKey key) where TCacheDataModel : ICacheDataModel;

    void SetItem<TCacheDataModel>(CacheSaveOptions<TCacheDataModel> saveOptions) where TCacheDataModel : ICacheDataModel;

    void RemoveItem(CacheKey key);

    void Clear();
}