using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Presenter.Core.ViewModels.Presenter.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Dialogs.Exception.Presenter.ViewModels.Presenter.Infrastructure.Extensions.DependencyInjection;

internal static class ServiceCollectionExtensions
{
    public static void AddExceptionDialogPresenterViewModel(this IServiceCollection @this)
    {
        @this.AddPresenterViewModel<ExceptionDialogPresenterViewModel>();
    }
}