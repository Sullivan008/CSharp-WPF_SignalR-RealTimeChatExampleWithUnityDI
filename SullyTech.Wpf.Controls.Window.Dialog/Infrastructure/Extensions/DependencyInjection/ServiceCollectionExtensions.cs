using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Dialog.Interfaces;

namespace SullyTech.Wpf.Controls.Window.Dialog.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddDialogWindow<TIDialogWindow, TDialogWindow>(this IServiceCollection @this)
        where TDialogWindow : TIDialogWindow
        where TIDialogWindow : IDialogWindow
    {
        @this.AddTransient(typeof(TIDialogWindow), typeof(TDialogWindow));
    }
}