using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Standard.Interfaces;

namespace SullyTech.Wpf.Controls.Window.Standard.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddStandardWindow<TIStandardWindow, TStandardWindow>(this IServiceCollection @this)
        where TStandardWindow : TIStandardWindow
        where TIStandardWindow : IStandardWindow
    {
        @this.AddTransient(typeof(TIStandardWindow), typeof(TStandardWindow));
    }
}