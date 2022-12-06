using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.MessageDialog.Presenter.Views.MessageDialog.ViewModels.Presenter;
using SullyTech.Wpf.Dialogs.MessageDialog.Presenter.Views.MessageDialog.ViewModels.Presenter.Initializer.Models;
using SullyTech.Wpf.Dialogs.MessageDialog.Presenter.Views.MessageDialog.ViewModels.PresenterData;
using SullyTech.Wpf.Dialogs.MessageDialog.Presenter.Views.MessageDialog.ViewModels.PresenterData.Initializer.Models;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.Presenter.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.PresenterData.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Presenter.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.PresenterData.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.Services.CurrentDialogWindow.Interfaces;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Presenter.Views.MessageDialog.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMessageDialogView(this IServiceCollection @this)
    {
        @this.AddPresenterViewModelInitializer<MessageDialogViewModel, MessageDialogViewModelInitializerModel>();
        @this.AddPresenterDataViewModelInitializer<MessageDialogDataViewModel, MessageDialogDataViewModelInitializerModel>();

        @this.AddPresenterDataViewModel<MessageDialogDataViewModel>();

        @this.AddPresenterViewModel<MessageDialogViewModel>(serviceProvider => (contentPresenterViewDataViewModel, currentWindowService) =>
            new MessageDialogViewModel((MessageDialogDataViewModel)contentPresenterViewDataViewModel, (ICurrentDialogWindowService)currentWindowService));
    }
}