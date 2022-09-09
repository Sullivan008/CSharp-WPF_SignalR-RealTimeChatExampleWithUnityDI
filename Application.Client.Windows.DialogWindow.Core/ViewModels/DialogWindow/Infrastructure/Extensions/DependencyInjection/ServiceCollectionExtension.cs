using Application.Client.Windows.DialogWindow.Core.ViewModels.DialogWindow.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.DialogWindow.Core.ViewModels.DialogWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDialogWindowViewModel<TDialogWindowViewModel>(this IServiceCollection @this)
        where TDialogWindowViewModel : IDialogWindowViewModel
    {
        @this.AddTransient(typeof(TDialogWindowViewModel));

        return @this;
    }
}