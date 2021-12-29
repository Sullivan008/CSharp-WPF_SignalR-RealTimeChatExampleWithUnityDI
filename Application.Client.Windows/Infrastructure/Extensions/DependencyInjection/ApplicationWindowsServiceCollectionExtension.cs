using Application.Client.Windows.Services;
using Application.Client.Windows.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Infrastructure.Extensions.DependencyInjection;

public static class ApplicationWindowsServiceCollectionExtension
{
    public static IServiceCollection AddApplicationWindow(this IServiceCollection @this)
    {
        @this.AddTransient<IApplicationWindowService, ApplicationWindowService>();

        return @this;
    }
}