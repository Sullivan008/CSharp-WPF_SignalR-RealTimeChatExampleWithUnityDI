using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static void AddContentPresenterViewDataViewModel<TContentPresenterViewDataViewModel>(this IServiceCollection @this)
        where TContentPresenterViewDataViewModel : IContentPresenterViewDataViewModel
    {
        @this.AddTransient(typeof(TContentPresenterViewDataViewModel));
    }
}