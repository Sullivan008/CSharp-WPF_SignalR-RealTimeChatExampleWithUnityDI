using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Mapping.Profiles.WindowSettings;

namespace SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Mapping.Profiles.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddDialogWindowSettingsViewModelMappingProfile(this IServiceCollection @this)
    {
        @this.AddAutoMapper(config =>
        {
            config.AddProfile<DialogWindowSettingsViewModelMappingProfile>();
        });
    }
}