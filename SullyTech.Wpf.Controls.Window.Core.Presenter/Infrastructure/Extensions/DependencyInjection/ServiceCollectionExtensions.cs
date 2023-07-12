using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Core.Presenter.Interfaces;

namespace SullyTech.Wpf.Controls.Window.Core.Presenter.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddPresenter<TIPresenter, TPresenter>(this IServiceCollection @this)
        where TIPresenter : IPresenter
        where TPresenter : TIPresenter
    {
        @this.AddTransient(typeof(TIPresenter), typeof(TPresenter));
    }
}
