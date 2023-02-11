using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.MessageDialog.Services.MessageDialog.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMessageDialog(this IServiceCollection @this)
    {
        @this.AddMessageDialogWindow();

        @this.AddMessageDialogService();
    }
}