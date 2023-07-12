using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Interfaces.Window;

namespace SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Window.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddDialogWindowViewModel<TIDialogWindowViewModel, TDialogWindowViewModel>(this IServiceCollection @this)
        where TDialogWindowViewModel : TIDialogWindowViewModel
        where TIDialogWindowViewModel : IDialogWindowViewModel
    {
        @this.AddTransient(typeof(TIDialogWindowViewModel), typeof(TDialogWindowViewModel));
    }

    public static void AddDialogWindowSubViewModel<TIDialogWindowSubViewModel, TDialogWindowSubViewModel>(this IServiceCollection @this)
        where TDialogWindowSubViewModel : TIDialogWindowSubViewModel
        where TIDialogWindowSubViewModel : IDialogWindowViewModel
    {
        @this.AddTransient(typeof(TIDialogWindowSubViewModel), typeof(TDialogWindowSubViewModel));
    }
}