using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.Interfaces;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.Initializers.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.Window.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Window.Infrastructure.Extensions.DependencyInjection;

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