using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using Application.Client.Core.AppCacheStorage.Exceptions;
using Application.Client.Core.AppCacheStorage.Models;
using Application.Client.Core.AppCacheStorage.Models.StorageItemDataModels.Interfaces;
using Application.Client.Core.AppCacheStorage.Services.Interfaces;
using Application.Client.Core.AppCacheStorage.StaticValues;
using Application.Client.Core.AppCacheStorage.StaticValues.Enums;
using Newtonsoft.Json;

namespace Application.Client.Core.AppCacheStorage.Services
{
    public class AppCacheStorageService : IAppCacheStorageService
    {
        private readonly ObjectCache _memoryCache;

        public AppCacheStorageService()
        {
            _memoryCache = MemoryCache.Default;
        }

        public bool IsStorageKeyExist(AppCacheStorageKey key)
        {
            return _memoryCache.Any(x => x.Key == StaticValues.AppCacheStorages.GetAppCacheStorageKey(key));
        }

        public TAppCacheStorageDataModel GetItem<TAppCacheStorageDataModel>(AppCacheStorageKey key) where TAppCacheStorageDataModel : IAppCacheStorageDataModel
        {
            CacheItem cacheItem = _memoryCache.GetCacheItem(StaticValues.AppCacheStorages.GetAppCacheStorageKey(key));

            if (cacheItem == null)
            {
                throw new CacheItemNotExistException($"There is no item in the cache with the following key: {key}");
            }

            return JsonConvert.DeserializeObject<TAppCacheStorageDataModel>(cacheItem.Value.ToString());
        }

        public void SetItem<TAppCacheStorageDataModel>(CacheStorageSaveOptions<TAppCacheStorageDataModel> saveOptions) where TAppCacheStorageDataModel : IAppCacheStorageDataModel
        {
            string dataAsJson = JsonConvert.SerializeObject(saveOptions.Data);

            _memoryCache.Set(StaticValues.AppCacheStorages.GetAppCacheStorageKey(saveOptions.Key), dataAsJson, saveOptions.CacheItemPolicy);
        }

        public void RemoveItem(AppCacheStorageKey key)
        {
            if (IsStorageKeyExist(key))
            {
                _memoryCache.Remove(StaticValues.AppCacheStorages.GetAppCacheStorageKey(key));
            }
        }

        public void ClearStorage()
        {
            IEnumerable<string> keys = _memoryCache.Select(kvp => kvp.Key);

            foreach (string key in keys)
            {
                _memoryCache.Remove(key);
            }
        }
    }
}
