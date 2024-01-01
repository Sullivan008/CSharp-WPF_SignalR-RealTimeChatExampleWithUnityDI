using Microsoft.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Controls.Presenter.Core.UserControls.Presenter.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddPresenter<TPresenter>(this IServiceCollection @this)
        where TPresenter : Presenter
    {
        @this.AddTransient(typeof(TPresenter));
    }
}
