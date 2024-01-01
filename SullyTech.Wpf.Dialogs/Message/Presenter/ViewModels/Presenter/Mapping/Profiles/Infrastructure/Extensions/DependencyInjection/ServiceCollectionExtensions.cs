using Microsoft.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Dialogs.Message.Presenter.ViewModels.Presenter.Mapping.Profiles.Infrastructure.Extensions.DependencyInjection;

internal static class ServiceCollectionExtensions
{
    public static void AddMessageDialogPresenterViewModelMappingProfile(this IServiceCollection @this)
    {
        @this.AddAutoMapper(config =>
        {
            config.AddProfile<MessageDialogPresenterViewModelMappingProfile>();
        });
    }
}