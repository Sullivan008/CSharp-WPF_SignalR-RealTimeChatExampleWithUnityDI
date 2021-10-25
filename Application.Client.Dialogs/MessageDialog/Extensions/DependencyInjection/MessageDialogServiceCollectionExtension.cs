using Application.Client.Dialogs.MessageDialog.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Dialogs.MessageDialog.Extensions.DependencyInjection
{
    public static class MessageDialogServiceCollectionExtension
    {
        public static IServiceCollection AddMessageDialog(this IServiceCollection @this)
        {
            @this.AddTransient<IMessageDialog, MessageDialog>();

            return @this;
        }
    }
}
