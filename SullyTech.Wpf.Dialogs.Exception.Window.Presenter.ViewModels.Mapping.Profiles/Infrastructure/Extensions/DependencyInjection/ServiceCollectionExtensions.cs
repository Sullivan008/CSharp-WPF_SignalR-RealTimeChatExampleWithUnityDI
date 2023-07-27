using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Mapping.Profiles.PresenterData;

namespace SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Mapping.Profiles.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddExceptionDialogPresenterDataViewModelMappingProfile(this IServiceCollection @this)
    {
        @this.AddAutoMapper(config =>
        {
            config.AddProfile<ExceptionDialogPresenterDataViewModelMappingProfile>();
        });
    }
}