using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Exception.Service.ExceptionDialog.Interfaces;

namespace SullyTech.Wpf.Dialogs.Exception.Service.ExceptionDialog.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddExceptionDialogService(this IServiceCollection @this)
    {
        @this.AddScoped<IExceptionDialogService, ExceptionDialogService>();
    }
}