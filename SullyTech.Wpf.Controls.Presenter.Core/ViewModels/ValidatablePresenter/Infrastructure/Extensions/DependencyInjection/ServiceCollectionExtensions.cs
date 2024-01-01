using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Presenter.Core.ViewModels.ValidatablePresenter.SubModels;

namespace SullyTech.Wpf.Controls.Presenter.Core.ViewModels.ValidatablePresenter.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddValidatablePresenterViewModel<TValidatablePresenterViewModel>(this IServiceCollection @this)
        where TValidatablePresenterViewModel : ValidatablePresenterViewModel<TValidatablePresenterViewModel>
    {
        @this.AddTransient(typeof(TValidatablePresenterViewModel));
    }

    public static void AddValidatablePresenterSubViewModel<TValidatablePresenterSubViewModel>(this IServiceCollection @this)
        where TValidatablePresenterSubViewModel : ValidatablePresenterSubViewModel<TValidatablePresenterSubViewModel>
    {
        @this.AddTransient(typeof(TValidatablePresenterSubViewModel));
    }
}