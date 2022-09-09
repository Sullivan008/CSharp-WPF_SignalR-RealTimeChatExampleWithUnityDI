using Application.Cache.Core.Services.ApplicationCache.Options.Models.RemoveOptions.Abstractions;
using Application.Cache.Core.Services.ApplicationCache.Options.Models.RemoveOptions.Interfaces;

namespace Application.Cache.Core.Services.ApplicationCache.Options.Models.RemoveOptions;

internal class RemoveOptions<TCacheKey> : RemoveCacheOptions<TCacheKey>, IRemoveOptions<TCacheKey>
    where TCacheKey : Enum
{ }