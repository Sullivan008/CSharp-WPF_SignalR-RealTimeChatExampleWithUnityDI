using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.BusinessLogic.Modules.UserManagement.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddUserManagementBusinessLogic(this IServiceCollection @this)
    {
        @this.AddMediatR(Assembly.GetExecutingAssembly());

        return @this;
    }
}