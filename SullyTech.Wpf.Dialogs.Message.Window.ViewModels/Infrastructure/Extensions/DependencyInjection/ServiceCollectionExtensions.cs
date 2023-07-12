using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Window.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.WindowSettings.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Window;
using SullyTech.Wpf.Dialogs.Message.Window.ViewModels.WindowSettings;

namespace SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Infrastructure.Extensions.DependencyInjection;

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