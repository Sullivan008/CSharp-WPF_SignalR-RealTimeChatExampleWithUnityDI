using Application.Common.Utilities.Guard;

namespace Application.Cache.Services.ApplicationCacheService.Options.Models.Remove;

public class RemoveOptions<TCacheKey>
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