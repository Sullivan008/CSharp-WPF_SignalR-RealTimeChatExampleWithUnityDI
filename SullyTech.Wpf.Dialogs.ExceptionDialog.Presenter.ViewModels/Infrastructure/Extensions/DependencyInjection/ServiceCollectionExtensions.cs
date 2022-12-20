using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Presenter.ViewModels.Presenter;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Presenter.ViewModels.PresenterData;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Presenter.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.PresenterData.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Presenter.ViewModels.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddExceptionDialogPresenterViewModel(this IServiceCollection @this)
    {
        @this.AddPresenterViewModel<IExceptionDialogViewModel, ExceptionDialogViewModel>();
    }

    public static void AddExceptionDialogPresenterDataViewModel(this IServiceCollection @this)
    {
        @this.AddPresenterDataViewModel<IExceptionDialogDataViewModel, ExceptionDialogDataViewModel>();
    }
}