using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Interfaces.Presenter;

namespace SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Presenter.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddPresenterViewModel<TIPresenterViewModel, TPresenterViewModel>(this IServiceCollection @this)
        where TPresenterViewModel : TIPresenterViewModel
        where TIPresenterViewModel : IPresenterViewModel
    {
        @this.AddTransient(typeof(TIPresenterViewModel), typeof(TPresenterViewModel));
    }
}