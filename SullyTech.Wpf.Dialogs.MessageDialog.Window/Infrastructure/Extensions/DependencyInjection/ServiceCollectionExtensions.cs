using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.MessageDialog.Presenter.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.Window;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.WindowSettings;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.WindowSettings.Initializer.Models;
using SullyTech.Wpf.Windows.Dialog.ViewModels.DialogWindow.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.ViewModels.DialogWindowSettings.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindowSettings.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.Window.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Window.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMessageDialog(this IServiceCollection @this)
    {
        @this.AddDialogWindow<MessageDialogWindow>();

        @this.AddDialogWindowViewModel<MessageDialogWindowViewModel>();
        @this.AddDialogWindowSettingsViewModel<MessageDialogWindowSettingsViewModel>();

        @this.AddDialogWindowSettingsViewModelInitializer<MessageDialogWindowSettingsViewModel, MessageDialogWindowSettingsViewModelInitializerModel>();

        @this.AddMessageDialogPresenter();
    }
}