using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.Infrastructure.Extensions.DependencyInjection;

public static class NavigationWindowViewModelInitializerServiceCollectionExtension
{
    public static IServiceCollection AddNavigationWindowViewModelInitializer(this IServiceCollection @this, KeyValuePair<Type, Type> navigationWindowViewModelInitializer)
    {
        @this.AddTransient(navigationWindowViewModelInitializer.Key, navigationWindowViewModelInitializer.Value);

        return @this;
    }
}