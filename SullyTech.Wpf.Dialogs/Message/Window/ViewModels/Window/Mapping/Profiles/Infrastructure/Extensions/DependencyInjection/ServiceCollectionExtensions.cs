using Microsoft.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Window.Mapping.Profiles.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMessageDialogWindowViewModelMappingProfile(this IServiceCollection @this)
    {
        @this.AddAutoMapper(config =>
        {
            config.AddProfile<MessageDialogWindowViewModelMappingProfile>();
        });
    }
}