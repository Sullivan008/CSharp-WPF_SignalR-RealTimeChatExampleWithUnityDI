using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Exception.Service.ExceptionDialog.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Exception.Window.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Dialogs.Exception.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddExceptionDialog(this IServiceCollection @this)
    {
        @this.AddExceptionDialogWindow();

        @this.AddExceptionDialogService();
    }
}