using Application.Common.Utilities.Guard;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Cache.Core.Services.ApplicationCache.Options.Models.SetCacheOptions.Abstractions;

public abstract class SetCacheOptions<TCacheKey> 
    where TCacheKey : Enum
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

    public MemoryCacheEntryOptions MemoryCacheEntryOptions { get; init; } = new() { Priority = CacheItemPriority.NeverRemove };
}