using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Standard.Core.UserControls.Infrastructure.Extensions.DependencyInjection;

namespace App.Client.Wpf.Windows.Main.UserControls.Infrastructure.Extensions.DependencyInjection;

internal static class ServiceCollectionExtensions
{
    public static void AddMainWindowWindowUserControl(this IServiceCollection @this)
    {
        @this.AddStandardWindow<MainWindow>();
    }
}