using Application.Client.Windows.ApplicationWindow.Services.CurrentApplicationWindow.Interfaces;
using Application.Client.Windows.ContentPresenter.ViewModels.ContentPresenter.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.ContentPresenter.ViewModels.ContentPresenter.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static void AddContentPresenterViewModelFactory<TContentPresenterViewModel>(this IServiceCollection @this, 
        Func<IServiceProvider, Func<ICurrentApplicationWindowService, TContentPresenterViewModel>> contentPresenterViewModelFactory) where TContentPresenterViewModel : IContentPresenterViewModel
    {
        @this.AddTransient(contentPresenterViewModelFactory);
    }
}