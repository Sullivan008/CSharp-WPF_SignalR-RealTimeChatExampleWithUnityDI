using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Presenter.Core.ViewModels.Presenter.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Dialogs.Message.Presenter.ViewModels.Presenter.Infrastructure.Extensions.DependencyInjection;

internal static class ServiceCollectionExtensions
{
    public static void AddMessageDialogPresenterViewModel(this IServiceCollection @this)
    {
        @this.AddPresenterViewModel<MessageDialogPresenterViewModel>();
    }
}