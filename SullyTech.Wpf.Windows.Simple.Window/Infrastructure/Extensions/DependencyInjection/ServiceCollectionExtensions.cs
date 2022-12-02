using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Simple.Window.Interfaces;

namespace SullyTech.Wpf.Windows.Simple.Window.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddSimpleWindow<TSimpleWindow>(this IServiceCollection @this)
        where TSimpleWindow : ISimpleWindow
    {
        @this.AddTransient(typeof(TSimpleWindow));
    }
}