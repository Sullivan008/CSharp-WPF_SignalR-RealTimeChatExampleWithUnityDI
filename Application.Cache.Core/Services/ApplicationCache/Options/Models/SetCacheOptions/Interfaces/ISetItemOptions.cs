using Application.Cache.Core.Models.CacheData.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Cache.Core.Services.ApplicationCache.Options.Models.SetCacheOptions.Interfaces;

public interface ISetItemOptions<out TCacheKey, out TCacheDataModel>
    where TCacheKey : Enum
    where TCacheDataModel : ICacheDataModel
{
    public TCacheKey Key { get; }

    public TCacheDataModel Data { get; }

    public MemoryCacheEntryOptions MemoryCacheEntryOptions { get; }
}