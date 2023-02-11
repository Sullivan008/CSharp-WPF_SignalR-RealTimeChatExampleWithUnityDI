using Microsoft.Extensions.DependencyInjection;
using SullyTech.App.Client.Wpf.Windows.Main.Window.ViewModels.Interfaces.Window;
using SullyTech.App.Client.Wpf.Windows.Main.Window.ViewModels.Interfaces.WindowSettings;
using SullyTech.App.Client.Wpf.Windows.Main.Window.ViewModels.Window;
using SullyTech.App.Client.Wpf.Windows.Main.Window.ViewModels.WindowSettings;
using SullyTech.Wpf.Windows.Navigation.Window.ViewModels.NavigationWindow.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Navigation.Window.ViewModels.NavigationWindowSettings.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.App.Client.Wpf.Windows.Main.Window.ViewModels.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMainWindowViewModel(this IServiceCollection @this)
    {
        @this.AddNavigationWindowViewModel<IMainWindowViewModel, MainWindowViewModel>();
    }

    public static void AddMainWindowSettingsViewModel(this IServiceCollection @this)
    {
        @this.AddNavigationWindowSettingsViewModel<IMainWindowSettingsViewModel, MainWindowSettingsViewModel>();
    }
}