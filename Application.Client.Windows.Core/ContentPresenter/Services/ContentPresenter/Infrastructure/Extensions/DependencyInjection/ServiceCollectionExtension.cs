using Application.Client.Windows.Core.ContentPresenter.Services.ContentPresenter.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Core.ContentPresenter.Services.ContentPresenter.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddContentPresenterService(this IServiceCollection @this)
    {
        @this.AddTransient<IContentPresenterService, ContentPresenterService>();

        return @this;
    }
}