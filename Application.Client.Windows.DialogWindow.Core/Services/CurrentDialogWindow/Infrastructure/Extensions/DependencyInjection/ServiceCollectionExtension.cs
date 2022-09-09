using Application.Client.Windows.DialogWindow.Core.Services.CurrentDialogWindow.Interfaces;
using Application.Client.Windows.DialogWindow.Core.Window.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.DialogWindow.Core.Services.CurrentDialogWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddCurrentDialogWindowService<TDialogWindow>(this IServiceCollection @this) 
        where TDialogWindow : IDialogWindow
    {
        @this.AddTransient<Func<TDialogWindow, ICurrentDialogWindowService>>(serviceProvider =>
            dialogWindow => new CurrentDialogWindowService(dialogWindow));

        return @this;
    }
}