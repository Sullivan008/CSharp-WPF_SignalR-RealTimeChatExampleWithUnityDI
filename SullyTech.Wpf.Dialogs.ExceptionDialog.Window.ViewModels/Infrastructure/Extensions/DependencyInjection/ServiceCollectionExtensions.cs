using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Window;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.WindowSettings;
using SullyTech.Wpf.Windows.Dialog.ViewModels.DialogWindow.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.ViewModels.DialogWindowSettings.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddExceptionDialogWindowViewModel(this IServiceCollection @this)
    {
        @this.AddDialogWindowViewModel<IExceptionDialogWindowViewModel, ExceptionDialogWindowViewModel>();
    }

    public static void AddExceptionDialogWindowSettingsViewModel(this IServiceCollection @this)
    {
        @this.AddDialogWindowSettingsViewModel<IExceptionDialogWindowSettingsViewModel, ExceptionDialogWindowSettingsViewModel>();
    }
}