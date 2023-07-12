using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Message.Services.MessageDialog.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Message.Window.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Dialogs.Message.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMessageDialog(this IServiceCollection @this)
    {
        @this.AddMessageDialogWindow();

        @this.AddMessageDialogService();
    }
}