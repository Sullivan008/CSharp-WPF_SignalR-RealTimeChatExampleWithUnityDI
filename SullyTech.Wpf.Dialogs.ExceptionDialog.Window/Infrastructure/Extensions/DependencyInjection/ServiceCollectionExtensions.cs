using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Interfaces;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Presenter.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Initializers.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.Window.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddExceptionDialogWindow(this IServiceCollection @this)
    {
        @this.AddDialogWindow<IExceptionDialogWindow, ExceptionDialogWindow>();

        @this.AddExceptionDialogWindowViewModel();
        @this.AddExceptionDialogWindowSettingsViewModel();

        @this.AddExceptionDialogWindowSettingsViewModelInitializer();

        @this.AddExceptionDialogPresenter();
    }
}