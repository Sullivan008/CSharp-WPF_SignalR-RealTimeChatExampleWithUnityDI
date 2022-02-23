﻿using Application.Cache.Core.Services.ApplicationCache.Options.Models.GetCacheOptions.Abstractions;
using Application.Cache.Core.Services.ApplicationCache.Options.Models.GetCacheOptions.Interfaces;

namespace Application.Cache.Core.Services.ApplicationCache.Options.Models.GetCacheOptions;

public class GetItemOptions<TCacheKey> : GetCacheOptions<TCacheKey>, IGetItemOptions<TCacheKey>
    where TCacheKey : Enum
{ }