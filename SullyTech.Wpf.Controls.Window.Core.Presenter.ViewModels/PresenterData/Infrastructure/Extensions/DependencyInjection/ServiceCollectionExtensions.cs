using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.PresenterData.SubInterfaces;

namespace SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.PresenterData.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddPresenterDataViewModel<TIPresenterDataViewModel, TPresenterDataViewModel>(this IServiceCollection @this)
        where TPresenterDataViewModel : TIPresenterDataViewModel
        where TIPresenterDataViewModel : IPresenterDataViewModel
    {
        @this.AddTransient(typeof(TIPresenterDataViewModel), typeof(TPresenterDataViewModel));
    }

    public static void AddPresenterDataSubViewModel<TIPresenterDataSubViewModel, TPresenterDataSubViewModel>(this IServiceCollection @this)
        where TPresenterDataSubViewModel : TIPresenterDataSubViewModel
        where TIPresenterDataSubViewModel : IPresenterDataSubViewModel
    {
        @this.AddTransient(typeof(TIPresenterDataSubViewModel), typeof(TPresenterDataSubViewModel));
    }
}