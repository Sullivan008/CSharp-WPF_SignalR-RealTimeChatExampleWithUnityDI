using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Presenter.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Window;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.WindowSettings;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.WindowSettings.Initializer.Models;
using SullyTech.Wpf.Windows.Dialog.Services.CurrentDialogWindow.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.ViewModels.DialogWindow.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindowSettings.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.Window.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddExceptionDialog(this IServiceCollection @this)
    {
        @this.AddDialogWindow<ExceptionDialogWindow>();
        @this.AddCurrentDialogWindowService<ExceptionDialogWindow>();

        @this.AddDialogWindowViewModel<ExceptionDialogWindowViewModel>();
        @this.AddDialogWindowSettingsViewModelInitializer<ExceptionDialogWindowSettingsViewModel, ExceptionDialogWindowSettingsViewModelInitializerModel>();

        @this.AddExceptionDialogPresenter();
    }
}