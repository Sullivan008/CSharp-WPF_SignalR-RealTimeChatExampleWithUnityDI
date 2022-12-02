using SullyTech.Guard;

namespace Application.Cache.Core.Services.ApplicationCache.Options.Models.RemoveOptions.Abstractions;

public abstract class RemoveCacheOptions<TCacheKey>
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
}
