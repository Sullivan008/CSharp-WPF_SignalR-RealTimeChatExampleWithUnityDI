using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Application.Client.Core.AppCacheStorage.StaticValues.Enums;

namespace Application.Client.Core.AppCacheStorage.StaticValues
{
    public static class AppCacheStorages
    {
        private static readonly ReadOnlyDictionary<AppCacheStorageKey, string> AppCacheStorageKeys;

        static AppCacheStorages()
        {
            AppCacheStorageKeys = new ReadOnlyDictionary<AppCacheStorageKey, string>(new Dictionary<AppCacheStorageKey, string>
            {
                { AppCacheStorageKey.Messages, "MESSAGES" },
                { AppCacheStorageKey.AppUser, "APP_USER" }
            });
        }

        public static string GetAppCacheStorageKey(AppCacheStorageKey key)
        {
            AppCacheStorageKeys.TryGetValue(key, out string result);

            if (result == null)
            {
                throw new ArgumentNullException(nameof(result), $@"The following App Cache Storage Key does not exist with this key. {nameof(key).ToUpper()}: {key}");
            }

            return result;
        }
    }
}
