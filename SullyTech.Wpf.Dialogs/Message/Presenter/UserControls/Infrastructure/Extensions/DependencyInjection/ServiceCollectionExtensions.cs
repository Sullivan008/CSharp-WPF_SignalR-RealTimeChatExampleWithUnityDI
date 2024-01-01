using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Presenter.Core.UserControls.Presenter.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Dialogs.Message.Presenter.UserControls.Infrastructure.Extensions.DependencyInjection;

internal static class ServiceCollectionExtensions
{
    public static void AddMessageDialogPresenter(this IServiceCollection @this)
    {
        @this.AddPresenter<MessageDialogPresenter>();
    }
}