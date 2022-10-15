using App.Core.Guard.Implementation;
using Application.Cache.Core.Collections.CacheData.Interfaces;
using Application.Cache.Core.Models.CacheData.Interfaces;
using Application.Cache.Core.Services.ApplicationCache.Options.Models.SetCacheOptions.Abstractions;
using Application.Cache.Core.Services.ApplicationCache.Options.Models.SetCacheOptions.Interfaces;

namespace Application.Cache.Core.Services.ApplicationCache.Options.Models.SetCacheOptions;

public class SetItemsOptions<TCacheKey, TCacheDataModel> : SetCacheOptions<TCacheKey>, ISetItemsOptions<TCacheKey, TCacheDataModel>
    where TCacheKey : Enum
    where TCacheDataModel : ICacheDataModel
{
    private readonly ICacheDataCollection<TCacheDataModel>? _data;
    public ICacheDataCollection<TCacheDataModel> Data
    {
        get
        {
            Guard.ThrowIfNull(_data, nameof(Data));

            return _data!;
        }

        init => _data = value;
    }
}