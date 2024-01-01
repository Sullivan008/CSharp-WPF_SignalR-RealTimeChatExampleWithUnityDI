using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Core.UserControls.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Controls.Window.Dialog.Core.UserControls.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddDialogWindow<TDialogWindow>(this IServiceCollection @this)
        where TDialogWindow : DialogWindow
    {
        @this.AddWindow<TDialogWindow>();
    }
}