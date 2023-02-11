using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Presenter.ViewModels.Initializers.PresenterData;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Initializers.PresenterData.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Initializers.PresenterData.Interfaces;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Presenter.ViewModels.Initializers.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddExceptionDialogPresenterDataViewModelInitializer(this IServiceCollection @this)
    {
        @this.AddPresenterDataViewModelInitializer<IExceptionDialogDataViewModel, IExceptionDialogDataViewModelInitializerModel,
            IPresenterDataViewModelInitializer<IExceptionDialogDataViewModel, IExceptionDialogDataViewModelInitializerModel>, ExceptionDialogDataViewModelInitializer>();
    }
}