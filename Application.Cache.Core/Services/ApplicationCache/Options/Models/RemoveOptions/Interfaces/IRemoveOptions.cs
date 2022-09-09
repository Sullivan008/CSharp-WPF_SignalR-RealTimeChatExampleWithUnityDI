namespace Application.Cache.Core.Services.ApplicationCache.Options.Models.RemoveOptions.Interfaces;

public interface IRemoveOptions<out TCacheKey>
    where TCacheKey : Enum
{
    public TCacheKey Key { get; }
}
