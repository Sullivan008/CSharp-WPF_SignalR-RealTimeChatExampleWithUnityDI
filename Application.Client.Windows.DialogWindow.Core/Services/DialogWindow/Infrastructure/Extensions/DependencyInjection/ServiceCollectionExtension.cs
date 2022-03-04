using Application.Client.Windows.DialogWindow.Core.Services.DialogWindow.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.DialogWindow.Core.Services.DialogWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDialogWindowService(this IServiceCollection @this)
    {
        @this.AddTransient<IDialogWindowService, DialogWindowService>();

        return @this;
    }
}