using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Dialog.Core.ViewModels.Window.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Window.Infrastructure.Extensions.DependencyInjection;

internal static class ServiceCollectionExtensions
{
    public static void AddExceptionDialogWindowViewModel(this IServiceCollection @this)
    {
        @this.AddDialogWindowViewModel<ExceptionDialogWindowViewModel>();
    }
}