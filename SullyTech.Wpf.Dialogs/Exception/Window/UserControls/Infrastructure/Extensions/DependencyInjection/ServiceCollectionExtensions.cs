using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Dialog.Core.UserControls.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Dialogs.Exception.Window.UserControls.Infrastructure.Extensions.DependencyInjection;

internal static class ServiceCollectionExtensions
{
    public static void AddExceptionDialogWindow(this IServiceCollection @this)
    {
        @this.AddDialogWindow<ExceptionDialogWindow>();
    }
}