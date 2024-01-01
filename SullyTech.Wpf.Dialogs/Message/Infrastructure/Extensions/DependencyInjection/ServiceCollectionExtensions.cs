using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Message.Presenter.UserControls.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Message.Presenter.ViewModels.Presenter.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Message.Presenter.ViewModels.Presenter.Mapping.Profiles.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Message.Window.UserControls.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Window.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Window.Mapping.Profiles.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Dialogs.Message.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMessageDialog(this IServiceCollection @this)
    {
        @this.AddMessageDialogWindow();
        @this.AddMessageDialogWindowViewModel();
        @this.AddMessageDialogWindowViewModelMappingProfile();

        @this.AddMessageDialogPresenter();
        @this.AddMessageDialogPresenterViewModel();
        @this.AddMessageDialogPresenterViewModelMappingProfile();
    }
}