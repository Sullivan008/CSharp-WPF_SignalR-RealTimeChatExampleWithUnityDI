using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Standard.Core.ViewModels.Window.SubModels;

namespace SullyTech.Wpf.Controls.Window.Standard.Core.ViewModels.Window.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddStandardWindowViewModel<TStandardWindowViewModel>(this IServiceCollection @this)
        where TStandardWindowViewModel : StandardWindowViewModel
    {
        @this.AddTransient(typeof(TStandardWindowViewModel));
    }

    public static void AddStandardWindowSubViewModel<TStandardWindowSubViewModel>(this IServiceCollection @this)
        where TStandardWindowSubViewModel : StandardWindowSubViewModel
    {
        @this.AddTransient(typeof(TStandardWindowSubViewModel));
    }
}