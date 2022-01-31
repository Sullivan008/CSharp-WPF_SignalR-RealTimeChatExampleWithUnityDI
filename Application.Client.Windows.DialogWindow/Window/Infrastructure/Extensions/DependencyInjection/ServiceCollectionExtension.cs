using Application.Client.Windows.DialogWindow.Services.CurrentDialogWindow.Interfaces;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Interfaces;
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

            Func<TDialogWindow, ICurrentDialogWindowService> currentDialogWindowServiceFactory =
                serviceProvider.GetRequiredService<Func<TDialogWindow, ICurrentDialogWindowService>>();

            ICurrentDialogWindowService currentDialogWindowService = currentDialogWindowServiceFactory(dialogWindow);

            IDialogWindowViewModel dialogWindowViewModel =
                (IDialogWindowViewModel) Activator.CreateInstance(typeof(TDialogWindowViewModel), dialogWindow);

            return dialogWindow;
        });

        return @this;
    }
}