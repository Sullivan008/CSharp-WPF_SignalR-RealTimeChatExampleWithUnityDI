using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Interfaces;
using Application.Client.Windows.Core.Services.CurrentWindowService.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static void AddContentPresenterViewModelFactory<TContentPresenterViewModel>(this IServiceCollection @this, 
        Func<IServiceProvider, Func<IContentPresenterViewDataViewModel, ICurrentWindowService, TContentPresenterViewModel>> contentPresenterViewModelFactory) 
            where TContentPresenterViewModel : IContentPresenterViewModel
    {
        @this.AddTransient(contentPresenterViewModelFactory);
    }
}