using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Presenter.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.PresenterData.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Presenter;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.PresenterData;

namespace SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMessageDialogPresenterViewModel(this IServiceCollection @this)
    {
        @this.AddPresenterViewModel<IMessageDialogPresenterViewModel, MessageDialogPresenterViewModel>();
    }

    public static void AddMessageDialogPresenterDataViewModel(this IServiceCollection @this)
    {
        @this.AddPresenterDataViewModel<IMessageDialogPresenterDataViewModel, MessageDialogPresenterDataViewModel>();
    }
}