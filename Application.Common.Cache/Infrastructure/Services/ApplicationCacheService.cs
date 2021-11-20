using Application.Common.Cache.Infrastructure.Models.Interfaces;
using Application.Common.Cache.Infrastructure.Models.Options;
using Application.Common.Cache.Infrastructure.Services.Interfaces;
using Application.Common.Utilities.Extensions;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Common.Cache.Infrastructure.Services;

public class ApplicationCacheService : IApplicationCacheService
{
    private readonly IMemoryCache _memoryCache;

    private readonly HashSet<object> _memoryCacheKeys;

    public ApplicationCacheService(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
        _memoryCacheKeys = new HashSet<object>();
    }

    public TCacheDataModel GetItem<TCacheKey, TCacheDataModel>(TCacheKey key) where TCacheKey : Enum
                                                                              where TCacheDataModel : ICacheDataModel
    {
        return _memoryCache.GetOrCreate(key.GetEnumMemberAttrValue(), entry =>
        {
            entry.Priority = CacheItemPriority.NeverRemove;

            return Activator.CreateInstance<TCacheDataModel>();
        });

    }

    public void SetItem<TCacheKey, TCacheDataModel>(CacheSaveOptions<TCacheKey, TCacheDataModel> saveOptions) where TCacheKey : Enum
                                                                                                              where TCacheDataModel : ICacheDataModel
    {
        _memoryCache.Set(saveOptions.Key.GetEnumMemberAttrValue(), saveOptions.Data, saveOptions.MemoryCacheEntryOptions);

        _memoryCacheKeys.Add(saveOptions.Key);
    }

    public void RemoveItem<TCacheKey>(TCacheKey key) where TCacheKey : Enum
    {
        _memoryCache.Remove(key.GetEnumMemberAttrValue());

        _memoryCacheKeys.Remove(key);
    }

    public void Clear()
    {
        foreach (object key in _memoryCacheKeys)
        {
            _memoryCache.Remove(key);
        }

        _memoryCacheKeys.Clear();
    }
}