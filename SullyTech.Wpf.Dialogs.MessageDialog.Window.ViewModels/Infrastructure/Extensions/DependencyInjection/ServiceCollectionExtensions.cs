using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.Window;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.WindowSettings;
using SullyTech.Wpf.Windows.Dialog.ViewModels.DialogWindow.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.ViewModels.DialogWindowSettings.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMessageDialogWindowViewModel(this IServiceCollection @this)
    {
        @this.AddDialogWindowViewModel<IMessageDialogWindowViewModel, MessageDialogWindowViewModel>();
    }

    public static void AddMessageDialogWindowSettingsViewModel(this IServiceCollection @this)
    {
        @this.AddDialogWindowSettingsViewModel<IMessageDialogWindowSettingsViewModel, MessageDialogWindowSettingsViewModel>();
    }
}