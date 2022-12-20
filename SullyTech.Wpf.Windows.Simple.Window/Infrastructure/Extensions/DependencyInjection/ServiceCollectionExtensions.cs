using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Simple.Window.Interfaces;

namespace SullyTech.Wpf.Windows.Simple.Window.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddSimpleWindow<TISimpleWindow, TSimpleWindow>(this IServiceCollection @this)
        where TSimpleWindow : TISimpleWindow
        where TISimpleWindow : ISimpleWindow
    {
        @this.AddTransient(typeof(TISimpleWindow), typeof(TSimpleWindow));
    }
}