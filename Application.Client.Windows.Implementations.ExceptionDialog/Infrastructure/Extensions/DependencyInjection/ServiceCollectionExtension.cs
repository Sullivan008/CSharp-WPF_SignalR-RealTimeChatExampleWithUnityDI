using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Implementations.ExceptionDialog.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddExceptionDialogWindow(this IServiceCollection @this)
    {
        return @this;
    }
}