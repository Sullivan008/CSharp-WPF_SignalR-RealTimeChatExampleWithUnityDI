using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Services.Presenter.Displayed.Interfaces;

namespace SullyTech.Wpf.Services.Presenter.Displayed.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddDisplayedPresenterService(this IServiceCollection @this)
    {
        @this.AddScoped<IDisplayedPresenterService, DisplayedPresenterService>();
    }
}