using System.Runtime.Caching;
using Application.Client.Core.AppCacheStorage.Models.StorageItemDataModels.Interfaces;
using Application.Client.Core.AppCacheStorage.StaticValues.Enums;

namespace Application.Client.Core.AppCacheStorage.Models
{
    public class CacheStorageSaveOptions<TAppCacheStorageDataModel> where TAppCacheStorageDataModel : IAppCacheStorageDataModel
    {
        public AppCacheStorageKey Key { get; }

        public TAppCacheStorageDataModel Data { get; }
        
        public CacheItemPolicy CacheItemPolicy { get; }

        public CacheStorageSaveOptions(AppCacheStorageKey key, TAppCacheStorageDataModel data, CacheItemPolicy cacheItemPolicy = null)
        {
            Key = key;
            Data = data;
            CacheItemPolicy = cacheItemPolicy ?? new CacheItemPolicy { Priority = CacheItemPriority.NotRemovable };
        }
    }
}
