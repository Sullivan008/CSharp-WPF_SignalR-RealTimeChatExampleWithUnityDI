using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Presenter.ViewModels.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Presenter.ViewModels.Initializers.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Presenter.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddExceptionDialogPresenter(this IServiceCollection @this)
    {
        @this.AddExceptionDialogPresenterViewModel();
        @this.AddExceptionDialogPresenterDataViewModel();

        @this.AddExceptionDialogPresenterDataViewModelInitializer();
    }
}