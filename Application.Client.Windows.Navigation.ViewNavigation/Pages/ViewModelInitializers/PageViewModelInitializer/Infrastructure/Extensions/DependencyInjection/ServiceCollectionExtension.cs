using Application.Common.Utilities.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModelInitializers.PageViewModelInitializer.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static void AddPageViewModelInitializer(this IServiceCollection @this, Type pageViewModelInitializerType, Type pageViewModelInitializerImplementationType)
    {
        @this.AddTransient(pageViewModelInitializerType, pageViewModelInitializerImplementationType);
    }

    public static void AddPageViewModelInitializers(this IServiceCollection @this, IReadOnlyDictionary<Type, Type> pageViewModelInitializers)
    {
        pageViewModelInitializers.Keys.ForEach(key =>
        {
            @this.AddPageViewModelInitializer(key, pageViewModelInitializers[key]);
        });
    }
}