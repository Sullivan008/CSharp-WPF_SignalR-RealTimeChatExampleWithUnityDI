using Application.Cache.Core.Collections.CacheData.Interfaces;
using Application.Cache.Core.Models.CacheData.Interfaces;

namespace Application.Cache.Repositories.ApplicationCacheRepository.Interfaces;

public interface IApplicationCacheRepository<TCacheKey, TCacheDataModel> 
    where TCacheKey : Enum
    where TCacheDataModel : ICacheDataModel
{
    public TCacheDataModel GetItem();

    public ICacheDataCollection<TCacheDataModel> GetCollection();

    public void SetItem(TCacheDataModel dataItem);

    public void SetCollection(ICacheDataCollection<TCacheDataModel> dataCollection);
}
