using Microsoft.Extensions.DependencyInjection;
using SullyTech.App.Client.Wpf.Windows.Main.Window.ViewModels.Initializers.WindowSettings;
using SullyTech.App.Client.Wpf.Windows.Main.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;
using SullyTech.App.Client.Wpf.Windows.Main.Window.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Windows.Navigation.Window.ViewModels.Initializers.NavigationWindowSettings.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Navigation.Window.ViewModels.Initializers.NavigationWindowSettings.Interfaces;

namespace SullyTech.App.Client.Wpf.Windows.Main.Window.ViewModels.Initializers.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMainWindowSettingsViewModelInitializer(this IServiceCollection @this)
    {
        @this.AddNavigationWindowSettingsViewModelInitializer<IMainWindowSettingsViewModel, IMainWindowSettingsViewModelInitializerModel,
            INavigationWindowSettingsViewModelInitializer<IMainWindowSettingsViewModel, IMainWindowSettingsViewModelInitializerModel>, MainWindowSettingsViewModelInitializer>();
    }
}