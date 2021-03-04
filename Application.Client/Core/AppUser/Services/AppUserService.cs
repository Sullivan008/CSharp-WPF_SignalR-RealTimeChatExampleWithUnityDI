using Application.Client.Core.AppCacheStorage.Models;
using Application.Client.Core.AppCacheStorage.Models.StorageItemDataModels.AppUser;
using Application.Client.Core.AppCacheStorage.Services.Interfaces;
using Application.Client.Core.AppCacheStorage.StaticValues.Enums;
using Application.Client.Core.AppUser.Exceptions;
using Application.Client.Core.AppUser.Services.Interfaces;

namespace Application.Client.Core.AppUser.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppCacheStorageService _appCacheStorageService;

        public AppUserService(IAppCacheStorageService appCacheStorageService)
        {
            _appCacheStorageService = appCacheStorageService;
        }

        public void SetAppUser(string userName)
        {
            _appCacheStorageService.SetItem(new CacheStorageSaveOptions<AppUserStorageItemDataModel>(AppCacheStorageKey.AppUser, new AppUserStorageItemDataModel(userName)));
        }

        public bool IsAppUserExist()
        {
            return _appCacheStorageService.IsStorageKeyExist(AppCacheStorageKey.AppUser);
        }

        public string GetUserName()
        {
            if (!IsAppUserExist())
            {
                throw new AppUserNotExistException("The application user does not exist!");
            }

            AppUserStorageItemDataModel storageItem = _appCacheStorageService.GetItem<AppUserStorageItemDataModel>(AppCacheStorageKey.AppUser);

            return storageItem.UserName;
        }

        public void RemoveAppUser()
        {
            if (IsAppUserExist())
            {
                _appCacheStorageService.RemoveItem(AppCacheStorageKey.AppUser);
            }
        }
    }
}
