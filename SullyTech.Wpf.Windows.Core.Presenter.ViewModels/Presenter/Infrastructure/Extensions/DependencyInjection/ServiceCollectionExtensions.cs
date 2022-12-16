using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Interfaces.Presenter;

namespace SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Presenter.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddPresenterViewModel<TPresenterViewModel>(this IServiceCollection @this)
        where TPresenterViewModel : IPresenterViewModel
    {
        @this.AddTransient(typeof(TPresenterViewModel));
    }
}