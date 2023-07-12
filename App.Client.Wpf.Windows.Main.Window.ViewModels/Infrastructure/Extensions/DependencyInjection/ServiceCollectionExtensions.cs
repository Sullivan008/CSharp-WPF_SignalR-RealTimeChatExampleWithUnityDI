using App.Client.Wpf.Windows.Main.Window.ViewModels.Interfaces.Window;
using App.Client.Wpf.Windows.Main.Window.ViewModels.Interfaces.WindowSettings;
using App.Client.Wpf.Windows.Main.Window.ViewModels.Window;
using App.Client.Wpf.Windows.Main.Window.ViewModels.WindowSettings;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Window.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.WindowSettings.Infrastructure.Extensions.DependencyInjection;

namespace App.Client.Wpf.Windows.Main.Window.ViewModels.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMainWindowViewModel(this IServiceCollection @this)
    {
        @this.AddStandardWindowViewModel<IMainWindowViewModel, MainWindowViewModel>();
    }

    public static void AddMainWindowSettingsViewModel(this IServiceCollection @this)
    {
        @this.AddStandardWindowSettingsViewModel<IMainWindowSettingsViewModel, MainWindowSettingsViewModel>();
    }
}