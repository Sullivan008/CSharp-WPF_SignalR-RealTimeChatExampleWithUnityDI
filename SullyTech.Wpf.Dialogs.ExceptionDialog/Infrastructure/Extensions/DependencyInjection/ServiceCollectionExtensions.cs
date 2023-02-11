using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Services.ExceptionDialog.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddExceptionDialog(this IServiceCollection @this)
    {
        @this.AddExceptionDialogWindow();

        @this.AddExceptionDialogService();
    }
}