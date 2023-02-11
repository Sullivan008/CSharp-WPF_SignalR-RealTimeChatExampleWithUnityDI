using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.Window.ViewModels.Interfaces.DialogWindow;

namespace SullyTech.Wpf.Windows.Dialog.Window.ViewModels.DialogWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddDialogWindowViewModel<TIDialogWindowViewModel, TDialogWindowViewModel>(this IServiceCollection @this)
        where TDialogWindowViewModel : TIDialogWindowViewModel
        where TIDialogWindowViewModel : IDialogWindowViewModel
    {
        @this.AddTransient(typeof(TIDialogWindowViewModel), typeof(TDialogWindowViewModel));
    }
}