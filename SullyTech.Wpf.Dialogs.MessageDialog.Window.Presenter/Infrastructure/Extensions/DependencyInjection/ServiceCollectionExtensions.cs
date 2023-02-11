using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Initializers.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.Infrastructure.Extensions.DependencyInjection;

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