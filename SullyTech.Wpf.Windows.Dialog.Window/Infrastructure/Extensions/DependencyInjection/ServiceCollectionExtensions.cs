using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.Window.Interfaces;

namespace SullyTech.Wpf.Windows.Dialog.Window.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddDialogWindow<TIDialogWindow, TDialogWindow>(this IServiceCollection @this)
        where TDialogWindow : TIDialogWindow
        where TIDialogWindow : IDialogWindow
    {
        @this.AddTransient(typeof(TIDialogWindow), typeof(TDialogWindow));
    }
}