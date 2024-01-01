using Microsoft.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Controls.Window.Core.UserControls.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddWindow<TWindow>(this IServiceCollection @this)
        where TWindow : Window
    {
        @this.AddTransient(typeof(TWindow));
    }
}