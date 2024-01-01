using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Dialog.Services.DialogWindow.Interfaces;

namespace SullyTech.Wpf.Controls.Window.Dialog.Services.DialogWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddDialogWindowService(this IServiceCollection @this)
    {
        @this.AddScoped<IDialogWindowService, DialogWindowService>();
    }
}