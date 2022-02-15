using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static void AddContentPresenterViewDataViewModelFactory<TContentPresenterViewDataViewModel>(this IServiceCollection @this,
        Func<IServiceProvider, Func<TContentPresenterViewDataViewModel>> contentPresenterViewDataViewModelFactory)
            where TContentPresenterViewDataViewModel : IContentPresenterViewDataViewModel
    {
        @this.AddTransient(contentPresenterViewDataViewModelFactory);
    }
}