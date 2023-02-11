using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Initializers.Presenter.Interfaces;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Initializers.Presenter.Models.Interfaces;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Interfaces.Presenter;

namespace SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Initializers.Presenter.Infrastructure.Extensions.DependencyInjection;

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