using Microsoft.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Controls.Window.Dialog.Core.ViewModels.Window.Mapping.Profiles.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddDialogWindowViewModelMappingProfile(this IServiceCollection @this)
    {
        @this.AddAutoMapper(config =>
        {
            config.AddProfile<DialogWindowViewModelMappingProfile>();
        });
    }
}