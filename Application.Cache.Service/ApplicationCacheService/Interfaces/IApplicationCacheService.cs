using Application.Cache.Core.Collections.CacheData.Interfaces;
using Application.Cache.Core.Models.CacheData.Interfaces;
using Application.Cache.Services.ApplicationCacheService.Options.Models.Get;
using Application.Cache.Services.ApplicationCacheService.Options.Models.Remove;
using Application.Cache.Services.ApplicationCacheService.Options.Models.Set;

namespace Application.Cache.Services.ApplicationCacheService.Interfaces;

public interface IApplicationCacheService
{
    TCacheDataModel GetItem<TCacheKey, TCacheDataModel>(GetItemOptions<TCacheKey> getItemOptions) 
        where TCacheKey : Enum
        where TCacheDataModel : ICacheDataModel;

    ICacheDataCollection<TCacheDataModel> GetCollection<TCacheKey, TCacheDataModel>(GetCollectionOptions<TCacheKey> getCollectionOptions)
        where TCacheKey : Enum
        where TCacheDataModel : ICacheDataModel;

    void SetItem<TCacheKey, TCacheDataModel>(SetItemOptions<TCacheKey, TCacheDataModel> setItemOptions) 
        where TCacheKey : Enum
        where TCacheDataModel : ICacheDataModel;

    void SetCollection<TCacheKey, TCacheDataModel>(SetCollectionOptions<TCacheKey, TCacheDataModel> setCollectionOptions) 
        where TCacheKey : Enum
        where TCacheDataModel : ICacheDataModel;

    void Remove<TCacheKey>(RemoveOptions<TCacheKey> removeOptions)
        where TCacheKey : Enum;

    void Clear();
}