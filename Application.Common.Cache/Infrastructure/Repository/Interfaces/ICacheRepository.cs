using Application.Common.Cache.Infrastructure.Models.Interfaces;

namespace Application.Common.Cache.Infrastructure.Repository.Interfaces;

public interface ICacheRepository<TCacheKey, TCacheDataModel> where TCacheKey : Enum
                                                              where TCacheDataModel : ICacheDataModel
{
    TCacheDataModel GetItem();

    void SetItem(TCacheDataModel data);
}