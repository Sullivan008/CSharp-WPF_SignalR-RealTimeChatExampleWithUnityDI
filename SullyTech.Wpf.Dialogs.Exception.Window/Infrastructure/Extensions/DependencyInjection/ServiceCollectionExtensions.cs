using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Dialog.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Exception.Window.Interfaces;
using SullyTech.Wpf.Dialogs.Exception.Window.Presenter.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Initializers.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Dialogs.Exception.Window.Infrastructure.Extensions.DependencyInjection;

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