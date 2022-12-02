using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.Services.CurrentDialogWindow.Interfaces;
using SullyTech.Wpf.Windows.Dialog.Window.Interfaces;

namespace SullyTech.Wpf.Windows.Dialog.Services.CurrentDialogWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCurrentDialogWindowService<TDialogWindow>(this IServiceCollection @this) 
        where TDialogWindow : IDialogWindow
    {
        @this.AddTransient<Func<TDialogWindow, ICurrentDialogWindowService>>(serviceProvider =>
            dialogWindow => new CurrentDialogWindowService(dialogWindow));

        return @this;
    }
}