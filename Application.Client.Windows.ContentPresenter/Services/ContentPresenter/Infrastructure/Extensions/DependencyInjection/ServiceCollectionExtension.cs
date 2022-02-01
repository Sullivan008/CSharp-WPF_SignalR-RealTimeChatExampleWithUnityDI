using Application.Client.Windows.ContentPresenter.Services.ContentPresenter.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.ContentPresenter.Services.ContentPresenter.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static void AddContentPresenterService(this IServiceCollection @this)
    {
        @this.AddTransient<IContentPresenterService, ContentPresenterService>();
    }
}