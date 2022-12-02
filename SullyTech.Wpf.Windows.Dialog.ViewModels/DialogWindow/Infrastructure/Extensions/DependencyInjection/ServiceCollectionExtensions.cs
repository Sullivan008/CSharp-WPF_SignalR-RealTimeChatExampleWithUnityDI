using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Interfaces.DialogWindow;

namespace SullyTech.Wpf.Windows.Dialog.ViewModels.DialogWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddDialogWindowViewModel<TDialogWindowViewModel>(this IServiceCollection @this)
        where TDialogWindowViewModel : IDialogWindowViewModel
    {
        @this.AddTransient(typeof(TDialogWindowViewModel));
    }
}