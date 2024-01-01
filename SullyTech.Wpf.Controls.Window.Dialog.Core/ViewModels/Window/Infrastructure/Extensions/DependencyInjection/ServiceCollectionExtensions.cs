using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Dialog.Core.ViewModels.Window.SubModels;

namespace SullyTech.Wpf.Controls.Window.Dialog.Core.ViewModels.Window.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddDialogWindowViewModel<TDialogWindowViewModel>(this IServiceCollection @this)
        where TDialogWindowViewModel : DialogWindowViewModel
    {
        @this.AddTransient(typeof(TDialogWindowViewModel));
    }

    public static void AddDialogWindowSubViewModel<TDialogWindowSubViewModel>(this IServiceCollection @this)
        where TDialogWindowSubViewModel : DialogWindowSubViewModel
    {
        @this.AddTransient(typeof(TDialogWindowSubViewModel));
    }
}