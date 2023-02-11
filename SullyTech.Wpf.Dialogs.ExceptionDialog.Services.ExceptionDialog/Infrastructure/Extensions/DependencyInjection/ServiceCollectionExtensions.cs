using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Services.ExceptionDialog.Interfaces;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Services.ExceptionDialog.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddExceptionDialogService(this IServiceCollection @this)
    {
        @this.AddScoped<IExceptionDialogService, ExceptionDialogService>();
    }
}