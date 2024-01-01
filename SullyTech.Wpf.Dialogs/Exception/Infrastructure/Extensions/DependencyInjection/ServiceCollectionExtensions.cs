using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Exception.Presenter.UserControls.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Exception.Presenter.ViewModels.Presenter.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Exception.Presenter.ViewModels.Presenter.Mapping.Profiles.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Exception.Window.UserControls.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Window.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Window.Mapping.Profiles.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Dialogs.Exception.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddExceptionDialog(this IServiceCollection @this)
    {
        @this.AddExceptionDialogWindow();
        @this.AddExceptionDialogWindowViewModel();
        @this.AddExceptionDialogWindowViewModelMappingProfile();

        @this.AddExceptionDialogPresenter();
        @this.AddExceptionDialogPresenterViewModel();
        @this.AddExceptionDialogPresenterViewModelMappingProfile();
    }
}