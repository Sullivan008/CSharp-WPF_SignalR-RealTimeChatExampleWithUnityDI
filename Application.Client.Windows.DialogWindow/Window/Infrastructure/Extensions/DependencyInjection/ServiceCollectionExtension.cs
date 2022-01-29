using Application.Client.Windows.DialogWindow.Window.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.DialogWindow.Window.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDialogWindow<TDialogWindow, TDialogWindowViewModel>(this IServiceCollection @this) where TDialogWindow : IDialogWindow
    {
        @this.AddTransient(typeof(TDialogWindow), serviceProvider =>
        {
            TDialogWindow dialogWindow = Activator.CreateInstance<TDialogWindow>();

            return dialogWindow;
        });

        return @this;
    }
}