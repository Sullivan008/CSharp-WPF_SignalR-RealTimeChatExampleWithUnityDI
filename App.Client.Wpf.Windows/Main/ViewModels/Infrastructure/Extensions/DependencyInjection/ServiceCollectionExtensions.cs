using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Standard.Core.ViewModels.Window.Infrastructure.Extensions.DependencyInjection;

namespace App.Client.Wpf.Windows.Main.ViewModels.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMainWindowViewModel(this IServiceCollection @this)
    {
        @this.AddStandardWindowViewModel<MainWindowViewModel>();
    }
}