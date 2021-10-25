using Application.Client.Core.AppCacheStorage.Models;
using Application.Client.Core.AppCacheStorage.Models.StorageItemDataModels.Interfaces;
using Application.Client.Core.AppCacheStorage.StaticValues.Enums;

namespace Application.Client.Core.AppCacheStorage.Services.Interfaces
{
    public interface IAppCacheStorageService
    {
        bool IsStorageKeyExist(AppCacheStorageKey key);

        TAppCacheStorageDataModel GetItem<TAppCacheStorageDataModel>(AppCacheStorageKey key) where TAppCacheStorageDataModel : IAppCacheStorageDataModel;

        void SetItem<TAppCacheStorageDataModel>(CacheStorageSaveOptions<TAppCacheStorageDataModel> saveOptions) where TAppCacheStorageDataModel : IAppCacheStorageDataModel;
        
        void RemoveItem(AppCacheStorageKey key);

        void ClearStorage();
    }
}
