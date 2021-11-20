using Application.Common.Cache.Infrastructure.Models.Interfaces;
using Application.Common.Cache.Infrastructure.Models.Options;
using Application.Common.Cache.Infrastructure.Services.Interfaces;

namespace Application.Common.Cache.Infrastructure.Repository.Abstractions;

public abstract class BaseCacheRepository<TCacheKey, TCacheDataModel> where TCacheKey : Enum
                                                                      where TCacheDataModel : ICacheDataModel
{
    private readonly IApplicationCacheService _applicationCacheService;

    protected BaseCacheRepository(IApplicationCacheService applicationCacheService)
    {
        _applicationCacheService = applicationCacheService;
    }

    public TCacheDataModel GetItem()
    {
        return _applicationCacheService.GetItem<TCacheKey, TCacheDataModel>(GetCacheKey());
    }

    public void SetItem(TCacheDataModel dataItem)
    {
        CacheSaveOptions<TCacheKey, TCacheDataModel> saveOptions = new()
        {
            Key = GetCacheKey(),
            Data = dataItem
        };

        _applicationCacheService.SetItem(saveOptions);
    }

    protected abstract TCacheKey GetCacheKey();
}