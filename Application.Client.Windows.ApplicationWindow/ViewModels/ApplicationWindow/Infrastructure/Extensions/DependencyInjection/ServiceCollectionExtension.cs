using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationWindowViewModel<TApplicationWindowViewModel>(this IServiceCollection @this)
        where TApplicationWindowViewModel : IApplicationWindowViewModel
    {
        @this.AddTransient(typeof(TApplicationWindowViewModel));

        return @this;
    }
}