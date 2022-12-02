using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.Window.Interfaces;

namespace SullyTech.Wpf.Windows.Dialog.Window.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddDialogWindow<TDialogWindow>(this IServiceCollection @this)
        where TDialogWindow : IDialogWindow
    {
        @this.AddTransient(typeof(TDialogWindow));
    }
}