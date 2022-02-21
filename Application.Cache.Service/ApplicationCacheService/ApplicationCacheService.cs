using Application.Cache.Core.Collections.CacheData;
using Application.Cache.Core.Collections.CacheData.Interfaces;
using Application.Cache.Core.Models.CacheData.Interfaces;
using Application.Cache.Services.ApplicationCacheService.Interfaces;
using Application.Cache.Services.ApplicationCacheService.Options.Models.Get;
using Application.Cache.Services.ApplicationCacheService.Options.Models.Remove;
using Application.Cache.Services.ApplicationCacheService.Options.Models.Set;
using Application.Common.Utilities.Extensions;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Cache.Services.ApplicationCacheService;

public class ApplicationCacheService : IApplicationCacheService
{
    private readonly IMemoryCache _memoryCache;

    private readonly HashSet<object> _memoryCacheKeys;

    public ApplicationCacheService(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
        _memoryCacheKeys = new HashSet<object>();
    }

    public TCacheDataModel GetItem<TCacheKey, TCacheDataModel>(GetItemOptions<TCacheKey> getItemOptions) 
        where TCacheKey : Enum 
        where TCacheDataModel : ICacheDataModel
    {
        return _memoryCache.GetOrCreate(getItemOptions.Key.GetEnumMemberAttrValue(), entry =>
        {
            entry.Priority = CacheItemPriority.NeverRemove;

            return Activator.CreateInstance<TCacheDataModel>();
        });
    }

    public ICacheDataCollection<TCacheDataModel> GetCollection<TCacheKey, TCacheDataModel>(GetCollectionOptions<TCacheKey> getCollectionOptions) 
        where TCacheKey : Enum 
        where TCacheDataModel : ICacheDataModel
    {
        return _memoryCache.GetOrCreate(getCollectionOptions.Key.GetEnumMemberAttrValue(), entry =>
        {
            entry.Priority = CacheItemPriority.NeverRemove;

            return Activator.CreateInstance<CacheDataCollection<TCacheDataModel>>();
        });
    }

    public void SetItem<TCacheKey, TCacheDataModel>(SetItemOptions<TCacheKey, TCacheDataModel> setItemOptions) 
        where TCacheKey : Enum 
        where TCacheDataModel : ICacheDataModel
    {
        _memoryCache.Set(setItemOptions.Key.GetEnumMemberAttrValue(), setItemOptions.Data, setItemOptions.MemoryCacheEntryOptions);

        _memoryCacheKeys.Add(setItemOptions.Key);
    }

    public void SetCollection<TCacheKey, TCacheDataModel>(SetCollectionOptions<TCacheKey, TCacheDataModel> setCollectionOptions) 
        where TCacheKey : Enum 
        where TCacheDataModel : ICacheDataModel
    {
        _memoryCache.Set(setCollectionOptions.Key.GetEnumMemberAttrValue(), setCollectionOptions.Data, setCollectionOptions.MemoryCacheEntryOptions);

        _memoryCacheKeys.Add(setCollectionOptions.Key);
    }

    public void Remove<TCacheKey>(RemoveOptions<TCacheKey> removeOptions) where TCacheKey : Enum
    {
        _memoryCache.Remove(removeOptions.Key.GetEnumMemberAttrValue());

        _memoryCacheKeys.Remove(removeOptions.Key);
    }

    public void Clear()
    {
        _memoryCacheKeys.ForEach(memoryCacheKey =>
        {
            _memoryCache.Remove(memoryCacheKey);
        });

        _memoryCacheKeys.Clear();
    }
}