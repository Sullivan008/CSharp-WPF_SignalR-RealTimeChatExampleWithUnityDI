using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializers.PresenterData.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializers.PresenterData.Interfaces;
using SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Initializers.PresenterData;
using SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;
using SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Initializers.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddExceptionDialogPresenterDataViewModelInitializer(this IServiceCollection @this)
    {
        @this.AddPresenterDataViewModelInitializer<
            IExceptionDialogPresenterDataViewModel,
            IExceptionDialogPresenterDataViewModelInitializerModel,
            IPresenterDataViewModelInitializer<IExceptionDialogPresenterDataViewModel, IExceptionDialogPresenterDataViewModelInitializerModel>,
            ExceptionDialogPresenterDataViewModelInitializer>();
    }
}