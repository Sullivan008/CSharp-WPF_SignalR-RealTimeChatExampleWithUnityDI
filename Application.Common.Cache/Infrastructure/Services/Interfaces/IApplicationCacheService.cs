using Application.Common.Cache.Infrastructure.Models.Interfaces;
using Application.Common.Cache.Infrastructure.Models.Options;

namespace Application.Common.Cache.Infrastructure.Services.Interfaces;

public interface IApplicationCacheService
{
    TCacheDataModel GetItem<TCacheKey, TCacheDataModel>(TCacheKey key) where TCacheKey : Enum
                                                                       where TCacheDataModel : ICacheDataModel;

    void SetItem<TCacheKey, TCacheDataModel>(CacheSaveOptions<TCacheKey, TCacheDataModel> saveOptions) where TCacheKey : Enum
                                                                                                       where TCacheDataModel : ICacheDataModel;

    void RemoveItem<TCacheKey>(TCacheKey key) where TCacheKey : Enum;

    void Clear();
}