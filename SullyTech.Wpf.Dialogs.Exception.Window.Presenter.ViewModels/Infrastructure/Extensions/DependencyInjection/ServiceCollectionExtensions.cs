using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Presenter.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.PresenterData.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Presenter;
using SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.PresenterData;

namespace SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddExceptionDialogPresenterViewModel(this IServiceCollection @this)
    {
        @this.AddPresenterViewModel<IExceptionDialogPresenterViewModel, ExceptionDialogPresenterViewModel>();
    }

    public static void AddExceptionDialogPresenterDataViewModel(this IServiceCollection @this)
    {
        @this.AddPresenterDataViewModel<IExceptionDialogPresenterDataViewModel, ExceptionDialogPresenterDataViewModel>();
    }
}