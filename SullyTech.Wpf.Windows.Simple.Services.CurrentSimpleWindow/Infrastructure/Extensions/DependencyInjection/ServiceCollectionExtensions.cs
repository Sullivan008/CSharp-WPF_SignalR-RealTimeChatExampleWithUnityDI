using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Simple.Services.CurrentSimpleWindow.Interfaces;
using SullyTech.Wpf.Windows.Simple.Window.Interfaces;

namespace SullyTech.Wpf.Windows.Simple.Services.CurrentSimpleWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddCurrentNavigationWindowService<TSimpleWindow>(this IServiceCollection @this)
        where TSimpleWindow : ISimpleWindow
    {
        @this.AddTransient<Func<TSimpleWindow, ICurrentSimpleWindowService>>(serviceProvider =>
            navigationWindow => new CurrentSimpleWindowService(navigationWindow));
    }
}