using Microsoft.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Dialogs.Exception.Presenter.ViewModels.Presenter.Mapping.Profiles.Infrastructure.Extensions.DependencyInjection;

internal static class ServiceCollectionExtensions
{
    public static void AddExceptionDialogPresenterViewModelMappingProfile(this IServiceCollection @this)
    {
        @this.AddAutoMapper(config =>
        {
            config.AddProfile<ExceptionDialogPresenterViewModelMappingProfile>();
        });
    }
}