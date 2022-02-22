using Application.Cache.Core.Services.ApplicationCache.Options.Models.GetCacheOptions.Abstractions;
using Application.Cache.Core.Services.ApplicationCache.Options.Models.GetCacheOptions.Interfaces;

namespace Application.Cache.Core.Services.ApplicationCache.Options.Models.GetCacheOptions;

public class GetItemsOptions<TCacheKey> : GetCacheOptions<TCacheKey>, IGetItemsOptions<TCacheKey>
    where TCacheKey : Enum
{ }