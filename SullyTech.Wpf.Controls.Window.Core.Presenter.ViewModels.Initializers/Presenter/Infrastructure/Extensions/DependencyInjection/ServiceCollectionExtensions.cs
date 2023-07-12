using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializers.Presenter.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializers.Presenter.Models.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.Presenter;

namespace SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializers.Presenter.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static void AddPresenterViewModelInitializer<TIPresenterViewModel, TIPresenterViewModelInitializerModel,
        TIPresenterViewModelInitializer, TPresenterViewModelInitializer>(this IServiceCollection @this)
            where TIPresenterViewModel : IPresenterViewModel
            where TIPresenterViewModelInitializerModel : IPresenterViewModelInitializerModel
            where TIPresenterViewModelInitializer : IPresenterViewModelInitializer<TIPresenterViewModel, TIPresenterViewModelInitializerModel>
            where TPresenterViewModelInitializer : TIPresenterViewModelInitializer
    {
        @this.AddScoped(typeof(TIPresenterViewModelInitializer), typeof(TPresenterViewModelInitializer));
    }
}