using Application.Client.Windows.DialogWindow.Services.DialogWindow.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.DialogWindow.Services.DialogWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDialogWindowService(this IServiceCollection @this)
    {
        @this.AddTransient<IDialogWindowService, DialogWindowService>();

        return @this;
    }
}