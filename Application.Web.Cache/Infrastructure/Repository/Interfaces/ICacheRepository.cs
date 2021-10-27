using Application.Web.Cache.Infrastructure.Models.Interfaces;

namespace Application.Web.Cache.Infrastructure.Repository.Interfaces
{
    public interface ICacheRepository<TCacheDataModel> where TCacheDataModel : ICacheDataModel
    {
        TCacheDataModel GetItem();

        void SetItem(TCacheDataModel data);
    }
}
