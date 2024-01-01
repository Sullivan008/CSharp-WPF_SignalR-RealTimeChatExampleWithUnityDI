using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Dialog.Core.ViewModels.Window.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Window.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMessageDialogWindowViewModel(this IServiceCollection @this)
    {
        @this.AddDialogWindowViewModel<MessageDialogWindowViewModel>();
    }
}