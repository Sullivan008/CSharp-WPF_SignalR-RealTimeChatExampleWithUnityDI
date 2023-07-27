using App.Client.Wpf.Windows.Main.Window.ViewModels.Mapping.Profiles.WindowSettings;
using Microsoft.Extensions.DependencyInjection;

namespace App.Client.Wpf.Windows.Main.Window.ViewModels.Mapping.Profiles.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMainWindowSettingsViewModelMappingProfile(this IServiceCollection @this)
    {
        @this.AddAutoMapper(config =>
        {
            config.AddProfile<MainWindowSettingsViewModelMappingProfile>();
        });
    }
}