using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.Presenter.Interfaces;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.Presenter.Models.Interfaces;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Interfaces.Presenter;

namespace SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.Presenter.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static void AddPresenterViewModelInitializer<TIPresenterViewModel, TIPresenterViewModelInitializerModel>(this IServiceCollection @this)
        where TIPresenterViewModel : IPresenterViewModel
        where TIPresenterViewModelInitializerModel : IPresenterViewModelInitializerModel
    {
        Type implementationInterfaceType =
            typeof(IPresenterViewModelInitializer<TIPresenterViewModel, TIPresenterViewModelInitializerModel>);

        Type implementationType =
            Assembly.GetCallingAssembly().DefinedTypes.Where(x => x.IsClass)
                                                      .Where(x => !x.IsAbstract)
                                                      .Single(x => x.GetInterfaces().Any(y => y == implementationInterfaceType && y.IsGenericType));

        @this.AddTransient(implementationInterfaceType, implementationType);
    }
}