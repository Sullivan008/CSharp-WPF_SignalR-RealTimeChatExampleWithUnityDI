using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializers.PresenterData.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializers.PresenterData.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddPresenterDataViewModelInitializer<TIPresenterDataViewModel, TIPresenterDataViewModelInitializerModel,
        TIPresenterDataViewModelInitializer, TPresenterDataViewModelInitializer>(this IServiceCollection @this)
            where TIPresenterDataViewModel : IPresenterDataViewModel
            where TIPresenterDataViewModelInitializerModel : IPresenterDataViewModelInitializerModel
            where TIPresenterDataViewModelInitializer : IPresenterDataViewModelInitializer<TIPresenterDataViewModel, TIPresenterDataViewModelInitializerModel>
            where TPresenterDataViewModelInitializer : TIPresenterDataViewModelInitializer
    {
            @this.AddScoped(typeof(TIPresenterDataViewModelInitializer), typeof(TPresenterDataViewModelInitializer));
    }
}