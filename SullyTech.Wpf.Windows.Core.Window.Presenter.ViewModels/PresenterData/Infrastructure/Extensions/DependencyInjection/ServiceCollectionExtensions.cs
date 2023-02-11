using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.PresenterData.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddPresenterDataViewModel<TIPresenterDataViewModel, TPresenterDataViewModel>(this IServiceCollection @this)
        where TPresenterDataViewModel : TIPresenterDataViewModel
        where TIPresenterDataViewModel : IPresenterDataViewModel
    {
        @this.AddTransient(typeof(TIPresenterDataViewModel), typeof(TPresenterDataViewModel));
    }
}