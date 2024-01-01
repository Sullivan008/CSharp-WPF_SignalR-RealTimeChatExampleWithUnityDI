using Microsoft.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Window.Mapping.Profiles.Infrastructure.Extensions.DependencyInjection;

internal static class ServiceCollectionExtensions
{
    public static void AddExceptionDialogWindowViewModelMappingProfile(this IServiceCollection @this)
    {
        @this.AddAutoMapper(config =>
        {
            config.AddProfile<ExceptionDialogWindowViewModelMappingProfile>();
        });
    }
}