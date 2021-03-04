using System;
using Application.Client.Core.AppCacheStorage.Models.StorageItemDataModels.Interfaces;

namespace Application.Client.Core.AppCacheStorage.Models.StorageItemDataModels.AppUser
{
    public class AppUserStorageItemDataModel : IAppCacheStorageDataModel
    {
        public string UserName { get; }

        public AppUserStorageItemDataModel(string userName)
        {
            UserName = !string.IsNullOrWhiteSpace(userName) ? userName.Trim() : throw new ArgumentNullException(nameof(userName), @"The value cannot be null!");
        }
    }
}
