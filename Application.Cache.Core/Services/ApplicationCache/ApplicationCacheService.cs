using Application.Cache.Core.Collections.CacheData;
using Application.Cache.Core.Collections.CacheData.Interfaces;
using Application.Cache.Core.Models.CacheData.Interfaces;
using Application.Cache.Core.Services.ApplicationCache.Interfaces;
using Application.Cache.Core.Services.ApplicationCache.Options.Models.GetCacheOptions.Interfaces;
using Application.Cache.Core.Services.ApplicationCache.Options.Models.RemoveOptions.Interfaces;
using Application.Cache.Core.Services.ApplicationCache.Options.Models.SetCacheOptions.Interfaces;
using Application.Common.Utilities.Extensions;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Cache.Core.Services.ApplicationCache;

public class ApplicationCacheService : IApplicationCacheService
{
    private readonly IMemoryCache _memoryCache;

    private readonly HashSet<object> _memoryCacheKeys;

    public ApplicationCacheService(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
        _memoryCacheKeys = new HashSet<object>();
    }

    public TCacheDataModel GetItem<TCacheKey, TCacheDataModel>(IGetItemOptions<TCacheKey> options) 
        where TCacheKey : Enum 
        where TCacheDataModel : ICacheDataModel
    {
        return _memoryCache.GetOrCreate(options.Key.GetEnumMemberAttrValue(), entry =>
        {
            entry.Priority = CacheItemPriority.NeverRemove;

            return Activator.CreateInstance<TCacheDataModel>();
        });
    }

    public ICacheDataCollection<TCacheDataModel> GetItems<TCacheKey, TCacheDataModel>(IGetItemsOptions<TCacheKey> options) 
        where TCacheKey : Enum 
        where TCacheDataModel : ICacheDataModel
    {
        return _memoryCache.GetOrCreate(options.Key.GetEnumMemberAttrValue(), entry =>
        {
            entry.Priority = CacheItemPriority.NeverRemove;

            return Activator.CreateInstance<CacheDataCollection<TCacheDataModel>>();
        });
    }

    public void SetItem<TCacheKey, TCacheDataModel>(ISetItemOptions<TCacheKey, TCacheDataModel> options) 
        where TCacheKey : Enum 
        where TCacheDataModel : ICacheDataModel
    {
        _memoryCache.Set(options.Key.GetEnumMemberAttrValue(), options.Data, options.MemoryCacheEntryOptions);

        _memoryCacheKeys.Add(options.Key);
    }

    public void SetItems<TCacheKey, TCacheDataModel>(ISetItemsOptions<TCacheKey, TCacheDataModel> options) 
        where TCacheKey : Enum 
        where TCacheDataModel : ICacheDataModel
    {
        _memoryCache.Set(options.Key.GetEnumMemberAttrValue(), options.Data, options.MemoryCacheEntryOptions);

        _memoryCacheKeys.Add(options.Key);
    }

    public void Remove<TCacheKey>(IRemoveOptions<TCacheKey> options) 
        where TCacheKey : Enum
    {
        _memoryCache.Remove(options.Key.GetEnumMemberAttrValue());

        _memoryCacheKeys.Remove(options.Key);
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