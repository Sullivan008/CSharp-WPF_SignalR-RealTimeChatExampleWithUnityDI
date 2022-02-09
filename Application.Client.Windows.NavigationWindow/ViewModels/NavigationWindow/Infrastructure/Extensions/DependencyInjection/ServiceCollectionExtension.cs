using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddNavigationWindowViewModel<TNavigationWindowViewModel>(this IServiceCollection @this)
        where TNavigationWindowViewModel : INavigationWindowViewModel
    {
        @this.AddTransient(typeof(TNavigationWindowViewModel));

        return @this;
    }
}