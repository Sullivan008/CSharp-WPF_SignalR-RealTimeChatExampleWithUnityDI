using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Interfaces.Window.SubInterfaces;

namespace SullyTech.Wpf.Controls.Window.Standard.ViewModels.Window.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddStandardWindowViewModel<TIStandardWindowViewModel, TStandardWindowViewModel>(this IServiceCollection @this)
        where TStandardWindowViewModel : TIStandardWindowViewModel
        where TIStandardWindowViewModel : IStandardWindowViewModel
    {
        @this.AddTransient(typeof(TIStandardWindowViewModel), typeof(TStandardWindowViewModel));
    }

    public static void AddStandardWindowSubViewModel<TIStandardWindowSubViewModel, TStandardWindowSubViewModel>(this IServiceCollection @this)
        where TIStandardWindowSubViewModel : IStandardWindowSubViewModel
        where TStandardWindowSubViewModel : TIStandardWindowSubViewModel
    {
        @this.AddTransient(typeof(TIStandardWindowSubViewModel), typeof(TStandardWindowSubViewModel));
    }
}