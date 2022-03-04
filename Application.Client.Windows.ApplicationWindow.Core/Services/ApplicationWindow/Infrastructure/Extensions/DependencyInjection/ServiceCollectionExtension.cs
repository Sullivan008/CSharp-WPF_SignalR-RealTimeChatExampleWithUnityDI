using Application.Client.Windows.ApplicationWindow.Core.Services.ApplicationWindow.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.ApplicationWindow.Core.Services.ApplicationWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationWindowService(this IServiceCollection @this)
    {
        @this.AddTransient<IApplicationWindowService, ApplicationWindowService>();

        return @this;
    }
}