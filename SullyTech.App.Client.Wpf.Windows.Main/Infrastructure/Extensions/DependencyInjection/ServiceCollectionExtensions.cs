using Microsoft.Extensions.DependencyInjection;
using SullyTech.App.Client.Wpf.Windows.Main.Interfaces.Window;
using SullyTech.App.Client.Wpf.Windows.Main.ViewModels.Infrastructure.Extensions.DependencyInjection;
using SullyTech.App.Client.Wpf.Windows.Main.ViewModels.Initializers.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Navigation.Window.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.App.Client.Wpf.Windows.Main.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMainWindow(this IServiceCollection @this)
    {
        @this.AddNavigationWindow<IMainWindow, MainWindow>();

        @this.AddMainWindowViewModel();
        @this.AddMainWindowSettingsViewModel();

        @this.AddMainWindowSettingsViewModelInitializer();
    }
}