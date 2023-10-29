using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Mapping.Profiles.WindowSettings;

namespace SullyTech.Wpf.Controls.Window.Standard.ViewModels.Mapping.Profiles.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddStandardWindowSettingsViewModelMappingProfile(this IServiceCollection @this)
    {
        @this.AddAutoMapper(config =>
        {
            config.AddProfile<StandardWindowSettingsViewModelMappingProfile>();
        });
    }
}