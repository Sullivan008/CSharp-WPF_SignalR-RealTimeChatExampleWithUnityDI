using Application.Cache.Core.Models.CacheData.Interfaces;

namespace Application.Cache.Core.Collections.CacheData.Interfaces;

public interface ICacheDataCollection<TCacheDataModel> : ICollection<TCacheDataModel> 
    where TCacheDataModel : ICacheDataModel
{ }