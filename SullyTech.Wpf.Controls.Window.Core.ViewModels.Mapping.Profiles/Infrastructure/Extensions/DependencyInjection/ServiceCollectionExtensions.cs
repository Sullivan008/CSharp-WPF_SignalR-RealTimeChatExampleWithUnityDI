using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Core.ViewModels.Mapping.Profiles.WindowSettings;

namespace SullyTech.Wpf.Controls.Window.Core.ViewModels.Mapping.Profiles.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddWindowSettingsViewModelMappingProfile(this IServiceCollection @this)
    {
        @this.AddAutoMapper(config =>
        {
            config.AddProfile<WindowSettingsViewModelMappingProfile>();
        });
    }
}