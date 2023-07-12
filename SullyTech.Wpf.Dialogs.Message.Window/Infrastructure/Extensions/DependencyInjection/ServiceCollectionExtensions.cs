using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Dialog.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Message.Window.Interfaces;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Initializers.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Dialogs.Message.Window.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMessageDialogWindow(this IServiceCollection @this)
    {
        @this.AddDialogWindow<IMessageDialogWindow, MessageDialogWindow>();

        @this.AddMessageDialogWindowViewModel();
        @this.AddMessageDialogWindowSettingsViewModel();

        @this.AddMessageDialogWindowSettingsViewModelInitializer();

        @this.AddMessageDialogPresenter();
    }
}