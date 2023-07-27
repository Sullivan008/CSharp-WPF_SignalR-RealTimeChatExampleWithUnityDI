using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Mapping.Profiles.Presenter;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Mapping.Profiles.PresenterData;

namespace SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Mapping.Profiles.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMessageDialogPresenterViewModelMappingProfile(this IServiceCollection @this)
    {
        @this.AddAutoMapper(config =>
        {
            config.AddProfile<MessageDialogPresenterViewModelMappingProfile>();
        });
    }

    public static void AddMessageDialogPresenterDataViewModelMappingProfile(this IServiceCollection @this)
    {
        @this.AddAutoMapper(config =>
        {
            config.AddProfile<MessageDialogPresenterDataViewModelMappingProfile>();
        });
    }
}