using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Presenter.Core.ViewModels.Presenter.SubModels;

namespace SullyTech.Wpf.Controls.Presenter.Core.ViewModels.Presenter.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddPresenterViewModel<TPresenterViewModel>(this IServiceCollection @this)
    {
        @this.AddTransient(typeof(TPresenterViewModel));
    }

    public static void AddPresenterSubViewModel<TPresenterSubViewModel>(this IServiceCollection @this)
        where TPresenterSubViewModel : PresenterSubViewModel
    {
        @this.AddTransient(typeof(TPresenterSubViewModel));
    }
}