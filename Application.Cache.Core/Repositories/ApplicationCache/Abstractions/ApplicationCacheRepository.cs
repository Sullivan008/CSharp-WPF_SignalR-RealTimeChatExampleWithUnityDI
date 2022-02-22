using Application.Cache.Core.Collections.CacheData.Interfaces;
using Application.Cache.Core.Models.CacheData.Interfaces;
using Application.Cache.Core.Repositories.ApplicationCache.Interfaces;
using Application.Cache.Core.Services.ApplicationCache.Interfaces;
using Application.Cache.Core.Services.ApplicationCache.Options.Models.GetCacheOptions;
using Application.Cache.Core.Services.ApplicationCache.Options.Models.GetCacheOptions.Interfaces;
using Application.Cache.Core.Services.ApplicationCache.Options.Models.SetCacheOptions;
using Application.Cache.Core.Services.ApplicationCache.Options.Models.SetCacheOptions.Interfaces;

namespace Application.Cache.Core.Repositories.ApplicationCache.Abstractions;

public abstract class ApplicationCacheRepository<TCacheKey, TCacheDataModel> : IApplicationCacheRepository<TCacheKey, TCacheDataModel>
    where TCacheKey : Enum
    where TCacheDataModel : ICacheDataModel
{
    private readonly IApplicationCacheService _applicationCacheService;

    protected ApplicationCacheRepository(IApplicationCacheService applicationCacheService)
    {
        _applicationCacheService = applicationCacheService;
    }

    protected abstract TCacheKey CacheKey { get; }

    public TCacheDataModel GetItem()
    {
        IGetItemOptions<TCacheKey> options = new GetItemOptions<TCacheKey> { Key = CacheKey };

        return _applicationCacheService.GetItem<TCacheKey, TCacheDataModel>(options);
    }

    public ICacheDataCollection<TCacheDataModel> GetItems()
    {
        IGetItemsOptions<TCacheKey> options = new GetItemsOptions<TCacheKey> { Key = CacheKey };

        return _applicationCacheService.GetItems<TCacheKey, TCacheDataModel>(options);
    }

    public void SetItem(TCacheDataModel data)
    {
        ISetItemOptions<TCacheKey, TCacheDataModel> options = new SetItemOptions<TCacheKey, TCacheDataModel>
        {
            Key = CacheKey,
            Data = data
        };

        _applicationCacheService.SetItem(options);
    }

    public void SetItems(ICacheDataCollection<TCacheDataModel> data)
    {
        ISetItemsOptions<TCacheKey, TCacheDataModel> options = new SetItemsOptions<TCacheKey, TCacheDataModel>
        {
            Key = CacheKey,
            Data = data
        };

        _applicationCacheService.SetItems(options);
    }
}