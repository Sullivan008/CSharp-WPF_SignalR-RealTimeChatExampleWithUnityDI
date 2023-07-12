using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Core.Presenter.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.Interfaces;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Initializers.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Dialogs.Message.Window.Presenter.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMessageDialogPresenter(this IServiceCollection @this)
    {
        @this.AddPresenter<IMessageDialogPresenter, MessageDialogPresenter>();

        @this.AddMessageDialogPresenterViewModel();
        @this.AddMessageDialogPresenterDataViewModel();

        @this.AddMessageDialogPresenterViewModelInitializer();
        @this.AddMessageDialogPresenterDataViewModelInitializer();
    }
}