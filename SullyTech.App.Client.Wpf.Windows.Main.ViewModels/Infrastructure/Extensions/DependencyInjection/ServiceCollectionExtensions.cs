using Microsoft.Extensions.DependencyInjection;
using SullyTech.App.Client.Wpf.Windows.Main.ViewModels.Interfaces.Window;
using SullyTech.App.Client.Wpf.Windows.Main.ViewModels.Interfaces.WindowSettings;
using SullyTech.App.Client.Wpf.Windows.Main.ViewModels.Window;
using SullyTech.App.Client.Wpf.Windows.Main.ViewModels.WindowSettings;
using SullyTech.Wpf.Windows.Navigation.ViewModels.NavigationWindow.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Navigation.ViewModels.NavigationWindowSettings.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.App.Client.Wpf.Windows.Main.ViewModels.Infrastructure.Extensions.DependencyInjection;

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