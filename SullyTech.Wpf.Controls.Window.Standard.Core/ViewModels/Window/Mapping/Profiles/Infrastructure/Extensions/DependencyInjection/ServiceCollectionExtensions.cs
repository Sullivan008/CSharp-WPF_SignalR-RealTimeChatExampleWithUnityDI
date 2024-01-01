using Microsoft.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Controls.Window.Standard.Core.ViewModels.Window.Mapping.Profiles.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddStandardWindowViewModelMappingProfile(this IServiceCollection @this)
    {
        @this.AddAutoMapper(config =>
        {
            config.AddProfile<StandardWindowViewModelMappingProfile>();
        });
    }
}