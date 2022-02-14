using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Implementations.Exception.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddExceptionWindow(this IServiceCollection @this)
    {
        return @this;
    }
}