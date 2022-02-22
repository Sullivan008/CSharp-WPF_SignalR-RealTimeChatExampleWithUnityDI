namespace Application.Cache.Core.Services.ApplicationCache.Options.Models.GetCacheOptions.Interfaces;

public interface IGetItemOptions<out TCacheKey>
    where TCacheKey : Enum
{
    public TCacheKey Key { get; }
}