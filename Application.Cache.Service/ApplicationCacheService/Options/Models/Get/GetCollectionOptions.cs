using Application.Cache.Services.ApplicationCacheService.Options.Models.Get.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Cache.Services.ApplicationCacheService.Options.Models.Get;

public class GetCollectionOptions<TCacheKey> : IGetCollectionOptions
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