using App.Core.Guard.Implementation;
using Application.Cache.Core.Models.CacheData.Interfaces;
using Application.Cache.Core.Services.ApplicationCache.Options.Models.SetCacheOptions.Abstractions;
using Application.Cache.Core.Services.ApplicationCache.Options.Models.SetCacheOptions.Interfaces;

namespace Application.Cache.Core.Services.ApplicationCache.Options.Models.SetCacheOptions;

public class SetItemOptions<TCacheKey, TCacheDataModel> : SetCacheOptions<TCacheKey>, ISetItemOptions<TCacheKey, TCacheDataModel>
    where TCacheKey : Enum
    where TCacheDataModel : ICacheDataModel
{
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
}