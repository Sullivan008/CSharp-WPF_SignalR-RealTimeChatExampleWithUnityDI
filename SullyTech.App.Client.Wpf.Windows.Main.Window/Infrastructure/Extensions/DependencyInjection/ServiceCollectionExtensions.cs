using Microsoft.Extensions.DependencyInjection;
using SullyTech.App.Client.Wpf.Windows.Main.Window.Interfaces;
using SullyTech.App.Client.Wpf.Windows.Main.Window.ViewModels.Infrastructure.Extensions.DependencyInjection;
using SullyTech.App.Client.Wpf.Windows.Main.Window.ViewModels.Initializers.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Navigation.Window.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.App.Client.Wpf.Windows.Main.Window.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMainWindowWindowDependencies(this IServiceCollection @this)
    {
        @this.AddNavigationWindow<IMainWindow, MainWindow>();

        @this.AddMainWindowViewModel();
        @this.AddMainWindowSettingsViewModel();

        @this.AddMainWindowSettingsViewModelInitializer();
    }
}