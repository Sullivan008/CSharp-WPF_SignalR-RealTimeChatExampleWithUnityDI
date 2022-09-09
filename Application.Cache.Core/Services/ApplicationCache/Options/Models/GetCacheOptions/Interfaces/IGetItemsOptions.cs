namespace Application.Cache.Core.Services.ApplicationCache.Options.Models.GetCacheOptions.Interfaces;

public interface IGetItemsOptions<out TCacheKey>
    where TCacheKey : Enum
{
    public TCacheKey Key { get; }
}