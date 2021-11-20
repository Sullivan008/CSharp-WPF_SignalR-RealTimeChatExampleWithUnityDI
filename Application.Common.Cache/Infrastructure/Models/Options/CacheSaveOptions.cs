using Application.Common.Cache.Infrastructure.Models.Interfaces;
using Application.Common.Utilities.Guard;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Common.Cache.Infrastructure.Models.Options;

public class CacheSaveOptions<TCacheKey, TCacheDataItem> where TCacheKey : Enum 
                                                         where TCacheDataItem : ICacheDataModel
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