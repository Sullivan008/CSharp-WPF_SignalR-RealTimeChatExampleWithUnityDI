using System;
using System.Collections.Generic;
using Application.Utilities.Extensions;
using Application.Web.Cache.Infrastructure.Enums;
using Application.Web.Cache.Infrastructure.Models.Interfaces;
using Application.Web.Cache.Infrastructure.Models.Options;
using Application.Web.Cache.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Web.Cache.Infrastructure.Services
{
    public class ApplicationCacheService : IApplicationCacheService
    {
        private readonly IMemoryCache _memoryCache;

        private readonly HashSet<CacheKey> _memoryCacheKeys;

        public ApplicationCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _memoryCacheKeys = new HashSet<CacheKey>();
        }

        public TCacheDataModel GetItem<TCacheDataModel>(CacheKey key) where TCacheDataModel : ICacheDataModel
        {
            return _memoryCache.GetOrCreate(key.GetEnumMemberAttrValue(), entry =>
            {
                entry.Priority = CacheItemPriority.NeverRemove;

                return Activator.CreateInstance<TCacheDataModel>();
            });
        }

        public void SetItem<TCacheDataModel>(CacheSaveOptions<TCacheDataModel> saveOptions) where TCacheDataModel : ICacheDataModel
        {
            _memoryCache.Set(saveOptions.Key.GetEnumMemberAttrValue(), saveOptions.Data, saveOptions.MemoryCacheEntryOptions);

            _memoryCacheKeys.Add(saveOptions.Key);
        }

        public void RemoveItem(CacheKey key)
        {
            _memoryCache.Remove(key.GetEnumMemberAttrValue());

            _memoryCacheKeys.Remove(key);
        }

        public void Clear()
        {
            foreach (CacheKey key in _memoryCacheKeys)
            {
                _memoryCache.Remove(key);
            }

            _memoryCacheKeys.Clear();
        }
    }
}
