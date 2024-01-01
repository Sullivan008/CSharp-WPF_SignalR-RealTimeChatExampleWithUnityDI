using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Presenter.Core.UserControls.Presenter.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Dialogs.Exception.Presenter.UserControls.Infrastructure.Extensions.DependencyInjection;

internal static class ServiceCollectionExtensions
{
    public static void AddExceptionDialogPresenter(this IServiceCollection @this)
    {
        @this.AddPresenter<ExceptionDialogPresenter>();
    }
}