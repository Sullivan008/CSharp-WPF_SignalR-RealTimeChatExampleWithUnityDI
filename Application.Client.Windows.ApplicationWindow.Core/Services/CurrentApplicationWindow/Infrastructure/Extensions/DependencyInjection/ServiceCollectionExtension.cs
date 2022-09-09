using Application.Client.Windows.ApplicationWindow.Core.Services.CurrentApplicationWindow.Interfaces;
using Application.Client.Windows.ApplicationWindow.Core.Window.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.ApplicationWindow.Core.Services.CurrentApplicationWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddCurrentApplicationWindowService<TApplicationWindow>(this IServiceCollection @this) where TApplicationWindow : IApplicationWindow
    {
        @this.AddTransient<Func<TApplicationWindow, ICurrentApplicationWindowService>>(serviceProvider =>
            applicationWindow => new CurrentApplicationWindowService(applicationWindow));

        return @this;
    }
}