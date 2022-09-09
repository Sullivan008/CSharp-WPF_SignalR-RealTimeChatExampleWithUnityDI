using Application.Client.Windows.NavigationWindow.Core.ViewModels.NavigationWindow.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.NavigationWindow.Core.ViewModels.NavigationWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddNavigationWindowViewModel<TNavigationWindowViewModel>(this IServiceCollection @this)
        where TNavigationWindowViewModel : INavigationWindowViewModel
    {
        @this.AddTransient(typeof(TNavigationWindowViewModel));

        return @this;
    }
}