using Application.Cache.Core.Models.CacheData.Interfaces;
using Application.Cache.Services.ApplicationCacheService.Options.Models.Set.Interfaces;
using Application.Common.Utilities.Guard;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Cache.Services.ApplicationCacheService.Options.Models.Set;

public class SetItemOptions<TCacheKey, TCacheDataModel> : ISetItemOptions
    where TCacheKey : Enum
    where TCacheDataModel : ICacheDataModel
{
    private readonly TCacheKey? _key;
    public TCacheKey Key
    {
        get
        {
            Guard.ThrowIfNull(_key, nameof(Key));

            return _key!;
        }
        init => _key = value;
    }

    private readonly TCacheDataModel? _data;
    public TCacheDataModel Data
    {
        get
        {
            Guard.ThrowIfNull(_data, nameof(Data));

            return _data!;
        }
        init => _data = value;
    }

    public MemoryCacheEntryOptions MemoryCacheEntryOptions { get; init; } = new() { Priority = CacheItemPriority.NeverRemove };
}