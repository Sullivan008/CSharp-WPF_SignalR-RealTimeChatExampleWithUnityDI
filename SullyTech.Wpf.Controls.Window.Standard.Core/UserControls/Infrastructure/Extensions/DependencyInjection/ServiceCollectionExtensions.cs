using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Core.UserControls.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Controls.Window.Standard.Core.UserControls.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddStandardWindow<TStandardWindow>(this IServiceCollection @this)
        where TStandardWindow : StandardWindow
    {
        @this.AddWindow<TStandardWindow>();
    }
}