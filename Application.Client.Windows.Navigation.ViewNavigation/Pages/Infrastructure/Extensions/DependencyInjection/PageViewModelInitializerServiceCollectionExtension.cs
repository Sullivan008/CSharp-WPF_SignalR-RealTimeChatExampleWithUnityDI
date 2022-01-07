using Application.Common.Utilities.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Navigation.ViewNavigation.Pages.Infrastructure.Extensions.DependencyInjection;

public static class PageViewModelInitializerServiceCollectionExtension
{
    public static void AddPageViewModelInitializers(this IServiceCollection @this, IReadOnlyDictionary<Type, Type> pageViewModelInitializers)
    {
        pageViewModelInitializers.Keys.ForEach(key =>
        {
            @this.AddTransient(key, pageViewModelInitializers[key]);
        });
    }
}