using Application.Client.Windows.ApplicationWindow.Window.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.ApplicationWindow.Window.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationWindow<TApplicationWindow>(this IServiceCollection @this)
        where TApplicationWindow : IApplicationWindow
    {
        @this.AddTransient(typeof(TApplicationWindow));

        return @this;
    }
}