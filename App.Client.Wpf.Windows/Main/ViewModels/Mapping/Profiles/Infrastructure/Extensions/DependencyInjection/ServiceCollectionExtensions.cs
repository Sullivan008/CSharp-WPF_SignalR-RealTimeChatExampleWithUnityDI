using Microsoft.Extensions.DependencyInjection;

namespace App.Client.Wpf.Windows.Main.ViewModels.Mapping.Profiles.Infrastructure.Extensions.DependencyInjection;

internal static class ServiceCollectionExtensions
{
    public static void AddMainWindowViewModelMappingProfile(this IServiceCollection @this)
    {
        @this.AddAutoMapper(config =>
        {
            config.AddProfile<MainWindowViewModelMappingProfile>();
        });
    }
}