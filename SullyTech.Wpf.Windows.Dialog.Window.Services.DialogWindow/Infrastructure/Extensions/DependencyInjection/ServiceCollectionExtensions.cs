using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.Window.Services.DialogWindow.Interfaces;

namespace SullyTech.Wpf.Windows.Dialog.Window.Services.DialogWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddDialogWindowService(this IServiceCollection @this)
    {
        @this.AddTransient<IDialogWindowService, DialogWindowService>();
    }
}