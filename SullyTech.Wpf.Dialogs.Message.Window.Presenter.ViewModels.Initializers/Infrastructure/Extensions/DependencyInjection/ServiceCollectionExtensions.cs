using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializers.Presenter.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializers.Presenter.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializers.PresenterData.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializers.PresenterData.Interfaces;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Initializers.Presenter;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Initializers.Presenter.Models.Interfaces;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Initializers.PresenterData;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Initializers.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMessageDialogPresenterViewModelInitializer(this IServiceCollection @this)
    {
        @this.AddPresenterViewModelInitializer<
            IMessageDialogPresenterViewModel,
            IMessageDialogPresenterViewModelInitializerModel,
            IPresenterViewModelInitializer<IMessageDialogPresenterViewModel, IMessageDialogPresenterViewModelInitializerModel>,
            MessageDialogPresenterViewModelInitializer>();
    }

    public static void AddMessageDialogPresenterDataViewModelInitializer(this IServiceCollection @this)
    {
        @this.AddPresenterDataViewModelInitializer<
            IMessageDialogPresenterDataViewModel,
            IMessageDialogPresenterDataViewModelInitializerModel,
            IPresenterDataViewModelInitializer<IMessageDialogPresenterDataViewModel, IMessageDialogPresenterDataViewModelInitializerModel>,
            MessageDialogPresenterDataViewModelInitializer>();
    }
}