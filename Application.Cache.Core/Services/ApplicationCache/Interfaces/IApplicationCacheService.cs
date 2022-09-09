using Application.Cache.Core.Collections.CacheData.Interfaces;
using Application.Cache.Core.Models.CacheData.Interfaces;
using Application.Cache.Core.Services.ApplicationCache.Options.Models.GetCacheOptions.Interfaces;
using Application.Cache.Core.Services.ApplicationCache.Options.Models.RemoveOptions.Interfaces;
using Application.Cache.Core.Services.ApplicationCache.Options.Models.SetCacheOptions.Interfaces;

namespace Application.Cache.Core.Services.ApplicationCache.Interfaces;

public interface IApplicationCacheService
{
    public TCacheDataModel GetItem<TCacheKey, TCacheDataModel>(IGetItemOptions<TCacheKey> options)
        where TCacheKey : Enum
        where TCacheDataModel : ICacheDataModel;

    public ICacheDataCollection<TCacheDataModel> GetItems<TCacheKey, TCacheDataModel>(IGetItemsOptions<TCacheKey> options)
        where TCacheKey : Enum
        where TCacheDataModel : ICacheDataModel;

    public void SetItem<TCacheKey, TCacheDataModel>(ISetItemOptions<TCacheKey, TCacheDataModel> options)
        where TCacheKey : Enum
        where TCacheDataModel : ICacheDataModel;

    public void SetItems<TCacheKey, TCacheDataModel>(ISetItemsOptions<TCacheKey, TCacheDataModel> options)
        where TCacheKey : Enum
        where TCacheDataModel : ICacheDataModel;

    public void Remove<TCacheKey>(IRemoveOptions<TCacheKey> options)
        where TCacheKey : Enum;

    void Clear();
}