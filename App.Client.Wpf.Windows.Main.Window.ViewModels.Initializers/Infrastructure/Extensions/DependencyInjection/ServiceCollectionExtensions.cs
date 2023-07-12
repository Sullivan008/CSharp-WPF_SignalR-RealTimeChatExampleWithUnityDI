using App.Client.Wpf.Windows.Main.Window.ViewModels.Initializers.WindowSettings;
using App.Client.Wpf.Windows.Main.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;
using App.Client.Wpf.Windows.Main.Window.ViewModels.Interfaces.WindowSettings;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Initializers.WindowSettings.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Initializers.WindowSettings.Interfaces;

namespace App.Client.Wpf.Windows.Main.Window.ViewModels.Initializers.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMainWindowSettingsViewModelInitializer(this IServiceCollection @this)
    {
        @this.AddStandardWindowSettingsViewModelInitializer<
            IMainWindowSettingsViewModel,
            IMainWindowSettingsViewModelInitializerModel,
            IStandardWindowSettingsViewModelInitializer<IMainWindowSettingsViewModel, IMainWindowSettingsViewModelInitializerModel>,
            MainWindowSettingsViewModelInitializer>();
    }
}