using Application.Client.Windows.DialogWindow.Core.Window.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.DialogWindow.Core.Window.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDialogWindow<TDialogWindow>(this IServiceCollection @this) 
        where TDialogWindow : IDialogWindow
    {
        @this.AddTransient(typeof(TDialogWindow));

        return @this;
    }
}