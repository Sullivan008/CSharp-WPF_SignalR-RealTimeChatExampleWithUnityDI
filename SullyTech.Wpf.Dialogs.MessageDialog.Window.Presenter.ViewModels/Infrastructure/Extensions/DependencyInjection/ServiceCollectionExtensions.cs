using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Presenter;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.PresenterData;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Presenter.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.PresenterData.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMessageDialogPresenterViewModel(this IServiceCollection @this)
    {
        @this.AddPresenterViewModel<IMessageDialogViewModel, MessageDialogViewModel>();
    }

    public static void AddMessageDialogPresenterDataViewModel(this IServiceCollection @this)
    {
        @this.AddPresenterDataViewModel<IMessageDialogDataViewModel, MessageDialogDataViewModel>();
    }
}