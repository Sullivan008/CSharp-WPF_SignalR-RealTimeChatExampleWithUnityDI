using App.Client.Wpf.Windows.Main.Window.Interfaces;
using App.Client.Wpf.Windows.Main.Window.ViewModels.Infrastructure.Extensions.DependencyInjection;
using App.Client.Wpf.Windows.Main.Window.ViewModels.Mapping.Profiles.Infrastructure.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Standard.Infrastructure.Extensions.DependencyInjection;

namespace App.Client.Wpf.Windows.Main.Window.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMainWindowWindow(this IServiceCollection @this)
    {
        @this.AddStandardWindow<IMainWindow, MainWindow>();

        @this.AddMainWindowViewModel();
        @this.AddMainWindowSettingsViewModel();

        @this.AddMainWindowSettingsViewModelMappingProfile();
    }
}