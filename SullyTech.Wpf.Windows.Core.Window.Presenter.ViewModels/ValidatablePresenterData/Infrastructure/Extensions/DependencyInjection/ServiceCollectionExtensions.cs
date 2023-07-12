using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.ValidatablePresenterData;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.ValidatablePresenterData.SubInterfaces;

namespace SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.ValidatablePresenterData.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddValidatablePresenterDataViewModel<TIValidatablePresenterDataViewModel, TValidatablePresenterDataViewModel>(this IServiceCollection @this)
        where TValidatablePresenterDataViewModel : TIValidatablePresenterDataViewModel
        where TIValidatablePresenterDataViewModel : IValidatablePresenterDataViewModel
    {
        @this.AddTransient(typeof(TIValidatablePresenterDataViewModel), typeof(TValidatablePresenterDataViewModel));
    }

    public static void AddValidatablePresenterDataSubViewModel<TIValidatablePresenterDataSubViewModel, TValidatablePresenterDataSubViewModel>(this IServiceCollection @this)
        where TValidatablePresenterDataSubViewModel : TIValidatablePresenterDataSubViewModel
        where TIValidatablePresenterDataSubViewModel : IValidatablePresenterDataSubViewModel
    {
        @this.AddTransient(typeof(TIValidatablePresenterDataSubViewModel), typeof(TValidatablePresenterDataSubViewModel));
    }
}