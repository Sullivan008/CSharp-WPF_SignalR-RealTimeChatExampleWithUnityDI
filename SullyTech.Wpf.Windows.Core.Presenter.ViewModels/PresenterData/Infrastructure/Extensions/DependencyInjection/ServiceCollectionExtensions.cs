using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.Wpf.Windows.Core.Presenter.ViewModels.PresenterData.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddPresenterDataViewModel<TPresenterDataViewModel>(this IServiceCollection @this)
        where TPresenterDataViewModel : IPresenterDataViewModel
    {
        @this.AddTransient(typeof(TPresenterDataViewModel));
    }
}