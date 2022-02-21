using Application.BusinessLogic.Modules.UserManagement.Module.Cache.Repositories.UserCache.Models.CacheDataModels;
using Application.Cache.Repositories.ApplicationCacheRepository.Abstractions;
using Application.Cache.Repositories.ApplicationCacheRepository.Interfaces;
using Application.Cache.Services.ApplicationCacheService.Interfaces;

namespace Application.BusinessLogic.Modules.UserManagement.Module.Cache.Repositories.UserCache;

public class UserCacheRepository : ApplicationCacheRepository<UserManagementCacheKey,UserCacheDataModel>, IApplicationCacheRepository<UserManagementCacheKey, UserCacheDataModel>
{
    public UserCacheRepository(IApplicationCacheService applicationCacheService) : base(applicationCacheService)
    { }

    protected override UserManagementCacheKey CacheKey => UserManagementCacheKey.Users;
}