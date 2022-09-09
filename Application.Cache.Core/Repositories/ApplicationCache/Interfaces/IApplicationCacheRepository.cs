using Application.Cache.Core.Collections.CacheData.Interfaces;
using Application.Cache.Core.Models.CacheData.Interfaces;

namespace Application.Cache.Core.Repositories.ApplicationCache.Interfaces;

public interface IApplicationCacheRepository<TCacheKey, TCacheDataModel> 
    where TCacheKey : Enum
    where TCacheDataModel : ICacheDataModel
{
    public TCacheDataModel GetItem();

    public ICacheDataCollection<TCacheDataModel> GetItems();

    public void SetItem(TCacheDataModel data);

    public void SetItems(ICacheDataCollection<TCacheDataModel> data);
}
