using Application.Utilities.Guard;
using Application.Web.Cache.Infrastructure.Enums;
using Application.Web.Cache.Infrastructure.Models.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Web.Cache.Infrastructure.Models.Options;

public class CacheSaveOptions<TCacheDataItem> where TCacheDataItem : ICacheDataModel
{
    private readonly CacheKey? _key;
    public CacheKey Key
    {
        get
        {
            Guard.ThrowIfNull(_key, nameof(Key));
                
            return _key!.Value;
        }
        init => _key = value;
    }

    private readonly TCacheDataItem? _data;
    public TCacheDataItem Data
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