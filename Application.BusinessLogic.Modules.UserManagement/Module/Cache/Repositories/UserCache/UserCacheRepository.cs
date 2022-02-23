using Application.BusinessLogic.Modules.UserManagement.Module.Cache.Repositories.UserCache.Models.CacheDataModels;
using Application.Cache.Core.Repositories.ApplicationCache.Abstractions;
using Application.Cache.Core.Services.ApplicationCache.Interfaces;

namespace Application.BusinessLogic.Modules.UserManagement.Module.Cache.Repositories.UserCache;

public class UserCacheRepository : ApplicationCacheRepository<UserManagementCacheKey,UserCacheDataModel>
{
    public UserCacheRepository(IApplicationCacheService applicationCacheService) : base(applicationCacheService)
    { }

    protected override UserManagementCacheKey CacheKey => UserManagementCacheKey.Users;
}