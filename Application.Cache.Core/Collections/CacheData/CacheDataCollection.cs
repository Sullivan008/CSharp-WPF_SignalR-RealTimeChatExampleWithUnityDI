using System.Collections.ObjectModel;
using Application.Cache.Core.Collections.CacheData.Interfaces;
using Application.Cache.Core.Models.CacheData.Interfaces;

namespace Application.Cache.Core.Collections.CacheData;

public class CacheDataCollection<TCacheDataModel> : Collection<TCacheDataModel>, ICacheDataCollection<TCacheDataModel>
    where TCacheDataModel : ICacheDataModel
{ }