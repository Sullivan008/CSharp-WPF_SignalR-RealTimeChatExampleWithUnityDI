using Application.Client.Windows.Services.ApplicationWindow;
using Application.Client.Windows.Services.ApplicationWindow.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Services.Infrastructure.Extensions.DependencyInjection;

public static class ApplicationWindowsServiceCollectionExtension
{
    public static IServiceCollection AddApplicationWindowService(this IServiceCollection @this)
    {
        @this.AddTransient<IApplicationWindowService, ApplicationWindowService>();

        return @this;
    }
}