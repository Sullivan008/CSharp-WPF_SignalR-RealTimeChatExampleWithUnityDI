﻿using Application.Cache.Core.Collections.CacheData.Interfaces;
using Application.Cache.Core.Models.CacheData.Interfaces;
using Application.Cache.Services.ApplicationCacheService.Interfaces;
using Application.Cache.Services.ApplicationCacheService.Options.Models.Get;
using Application.Cache.Services.ApplicationCacheService.Options.Models.Set;

namespace Application.Cache.Repositories.ApplicationCacheRepository.Abstractions;

public abstract class ApplicationCacheRepository<TCacheKey, TCacheDataModel> 
    where TCacheKey : Enum
    where TCacheDataModel : ICacheDataModel
{
    private readonly IApplicationCacheService _applicationCacheService;

    protected ApplicationCacheRepository(IApplicationCacheService applicationCacheService)
    {
        _applicationCacheService = applicationCacheService;
    }

    public TCacheDataModel GetItem()
    {
        GetItemOptions<TCacheKey> getItemOptions = new() { Key = CacheKey };

        return _applicationCacheService.GetItem<TCacheKey, TCacheDataModel>(getItemOptions);
    }

    public ICacheDataCollection<TCacheDataModel> GetCollection()
    {
        GetCollectionOptions<TCacheKey> getCollectionOptions = new() { Key = CacheKey };

        return _applicationCacheService.GetCollection<TCacheKey, TCacheDataModel>(getCollectionOptions);
    }

    public void SetItem(TCacheDataModel dataItem)
    {
        SetItemOptions<TCacheKey, TCacheDataModel> setItemOptions = new()
        {
            Key = CacheKey,
            Data = dataItem
        };

        _applicationCacheService.SetItem(setItemOptions);
    }

    public void SetCollection(ICacheDataCollection<TCacheDataModel> dataCollection)
    {
        SetCollectionOptions<TCacheKey, TCacheDataModel> setCollectionOptions = new()
        {
            Key = CacheKey,
            Data = dataCollection
        };

        _applicationCacheService.SetCollection(setCollectionOptions);
    }

    protected abstract TCacheKey CacheKey { get; }
}