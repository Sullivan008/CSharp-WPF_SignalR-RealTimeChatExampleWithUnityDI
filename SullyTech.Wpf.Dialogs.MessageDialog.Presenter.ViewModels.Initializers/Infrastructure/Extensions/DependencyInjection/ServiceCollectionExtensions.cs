using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.MessageDialog.Presenter.ViewModels.Initializers.Presenter.Models.Interfaces;
using SullyTech.Wpf.Dialogs.MessageDialog.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;
using SullyTech.Wpf.Dialogs.MessageDialog.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Dialogs.MessageDialog.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.Presenter.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.PresenterData.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Presenter.ViewModels.Initializers.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMessageDialogPresenterViewModelInitializer(this IServiceCollection @this)
    {
        @this.AddPresenterViewModelInitializer<IMessageDialogViewModel, IMessageDialogViewModelInitializerModel>();
    }

    public static void AddMessageDialogPresenterDataViewModelInitializer(this IServiceCollection @this)
    {
        @this.AddPresenterDataViewModelInitializer<IMessageDialogDataViewModel, IMessageDialogDataViewModelInitializerModel>();
    }
}