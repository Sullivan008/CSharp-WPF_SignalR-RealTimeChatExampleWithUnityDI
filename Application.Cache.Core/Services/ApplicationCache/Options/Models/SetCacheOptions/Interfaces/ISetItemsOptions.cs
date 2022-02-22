using Application.Cache.Core.Collections.CacheData.Interfaces;
using Application.Cache.Core.Models.CacheData.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Cache.Core.Services.ApplicationCache.Options.Models.SetCacheOptions.Interfaces;
public interface ISetItemsOptions<out TCacheKey, TCacheDataModel>
    where TCacheKey : Enum
    where TCacheDataModel : ICacheDataModel
{
    public TCacheKey Key { get; }

    public ICacheDataCollection<TCacheDataModel> Data { get; }

    public MemoryCacheEntryOptions MemoryCacheEntryOptions { get; }
}
