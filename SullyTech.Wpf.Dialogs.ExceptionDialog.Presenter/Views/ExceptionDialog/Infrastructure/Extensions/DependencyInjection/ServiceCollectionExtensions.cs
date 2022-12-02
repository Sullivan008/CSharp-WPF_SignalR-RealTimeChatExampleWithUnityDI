using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Presenter.Views.ExceptionDialog.ViewModels.Presenter;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Presenter.Views.ExceptionDialog.ViewModels.PresenterData;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Presenter.Views.ExceptionDialog.ViewModels.PresenterData.Initializer.Models;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.PresenterData.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Presenter.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.PresenterData.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.Services.CurrentDialogWindow.Interfaces;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Presenter.Views.ExceptionDialog.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddExceptionDialogView(this IServiceCollection @this)
    {
        @this.AddPresenterDataViewModelInitializer<ExceptionDialogDataViewModel, ExceptionDialogDataViewModelInitializerModel>();

        @this.AddPresenterDataViewModel<ExceptionDialogDataViewModel>();

        @this.AddPresenterViewModel<ExceptionDialogViewModel>(serviceProvider => (contentPresenterViewDataViewModel, currentWindowService) =>
            new ExceptionDialogViewModel((ExceptionDialogDataViewModel)contentPresenterViewDataViewModel, serviceProvider.GetRequiredService<IHostEnvironment>(),
                                         (ICurrentDialogWindowService)currentWindowService));
    }
}