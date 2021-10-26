using Application.Client.Cache.Infrastructure.Models.Interfaces;

namespace Application.Client.Cache.Infrastructure.Repository.Interfaces
{
    public interface ICacheRepository<TCacheDataModel> where TCacheDataModel : ICacheDataModel
    {
        TCacheDataModel GetItem();

        void SetItem(TCacheDataModel data);
    }
}
