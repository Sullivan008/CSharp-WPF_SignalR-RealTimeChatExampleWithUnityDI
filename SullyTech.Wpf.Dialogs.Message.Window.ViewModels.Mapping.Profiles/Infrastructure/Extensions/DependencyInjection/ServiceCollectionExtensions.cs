using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Mapping.Profiles.WindowSettings;

namespace SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Mapping.Profiles.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMessageDialogWindowSettingsViewModelMappingProfile(this IServiceCollection @this)
    {
        @this.AddAutoMapper(config =>
        {
            config.AddProfile<MessageDialogWindowSettingsViewModelMappingProfile>();
        });
    }
}