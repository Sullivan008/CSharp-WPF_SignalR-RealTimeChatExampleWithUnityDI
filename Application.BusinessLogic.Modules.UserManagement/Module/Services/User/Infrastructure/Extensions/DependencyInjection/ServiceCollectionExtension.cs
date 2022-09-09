using Application.BusinessLogic.Modules.UserManagement.Module.Services.User.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.BusinessLogic.Modules.UserManagement.Module.Services.User.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddUserService(this IServiceCollection @this)
    {
        @this.AddScoped<IUserService, UserService>();

        return @this;
    }
}