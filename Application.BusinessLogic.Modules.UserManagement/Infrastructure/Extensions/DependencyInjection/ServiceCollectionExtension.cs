using System.Reflection;
using Application.BusinessLogic.Modules.UserManagement.Module.Services.User.Infrastructure.Extensions.DependencyInjection;
using Application.Cache.Core.Repositories.ApplicationCache.Infrastructure.Extensions.DependencyInjection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.BusinessLogic.Modules.UserManagement.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddUserManagementModule(this IServiceCollection @this)
    {
        @this.AddMediatR(Assembly.GetExecutingAssembly());
        
        @this.AddApplicationCacheRepositories();

        @this.AddUserService();

        return @this;
    }
}