using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Core.Presenter.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Exception.Window.Presenter.Interfaces;
using SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Initializers.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Dialogs.Exception.Window.Presenter.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddExceptionDialogPresenter(this IServiceCollection @this)
    {
        @this.AddPresenter<IExceptionDialogPresenter, ExceptionDialogPresenter>();

        @this.AddExceptionDialogPresenterViewModel();
        @this.AddExceptionDialogPresenterDataViewModel();

        @this.AddExceptionDialogPresenterDataViewModelInitializer();
    }
}