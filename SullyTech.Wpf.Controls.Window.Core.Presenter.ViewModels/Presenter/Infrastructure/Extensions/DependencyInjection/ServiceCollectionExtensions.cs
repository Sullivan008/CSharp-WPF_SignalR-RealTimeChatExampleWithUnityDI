using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.Presenter.SubInterfaces;

namespace SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Presenter.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddPresenterViewModel<TIPresenterViewModel, TPresenterViewModel>(this IServiceCollection @this)
        where TPresenterViewModel : TIPresenterViewModel
        where TIPresenterViewModel : IPresenterViewModel
    {
        @this.AddTransient(typeof(TIPresenterViewModel), typeof(TPresenterViewModel));
    }

    public static void AddPresenterSubViewModel<TIPresenterSubViewModel, TPresenterSubViewModel>(this IServiceCollection @this)
        where TPresenterSubViewModel : TIPresenterSubViewModel
        where TIPresenterSubViewModel : IPresenterSubViewModel
    {
        @this.AddTransient(typeof(TIPresenterSubViewModel), typeof(TPresenterSubViewModel));
    }
}