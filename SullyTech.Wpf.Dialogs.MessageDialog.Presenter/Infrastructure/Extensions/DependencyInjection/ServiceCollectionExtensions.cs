using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.MessageDialog.Presenter.ViewModels.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.MessageDialog.Presenter.ViewModels.Initializers.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Presenter.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMessageDialogPresenter(this IServiceCollection @this)
    {
        @this.AddMessageDialogPresenterViewModel();
        @this.AddMessageDialogPresenterDataViewModel();

        @this.AddMessageDialogPresenterViewModelInitializer();
        @this.AddMessageDialogPresenterDataViewModelInitializer();
    }
}