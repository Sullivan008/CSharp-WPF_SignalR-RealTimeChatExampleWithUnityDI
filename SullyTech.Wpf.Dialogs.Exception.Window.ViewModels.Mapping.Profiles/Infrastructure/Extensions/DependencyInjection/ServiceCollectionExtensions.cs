using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Mapping.Profiles.WindowSettings;

namespace SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Mapping.Profiles.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddExceptionDialogWindowSettingsViewModelMappingProfile(this IServiceCollection @this)
    {
        @this.AddAutoMapper(config =>
        {
            config.AddProfile<ExceptionDialogWindowSettingsViewModelMappingProfile>();
        });
    }
}