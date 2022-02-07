using Application.Client.Windows.Common.ContentPresenter.ViewModels.ContentPresenter.Interfaces;
using Application.Client.Windows.Common.Services.CurrentWindowService.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Common.ContentPresenter.ViewModels.ContentPresenter.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static void AddContentPresenterViewModelFactory<TContentPresenterViewModel>(this IServiceCollection @this, 
        Func<IServiceProvider, Func<ICurrentWindowService, TContentPresenterViewModel>> contentPresenterViewModelFactory) where TContentPresenterViewModel : IContentPresenterViewModel
    {
        @this.AddTransient(contentPresenterViewModelFactory);
    }
}