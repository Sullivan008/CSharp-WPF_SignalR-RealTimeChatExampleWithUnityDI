using System.Reflection;
using Application.Client.Windows.ApplicationWindow.Core.ViewModels.ApplicationWindowSettings.Initializers.Interfaces;
using Application.Client.Windows.ApplicationWindow.Core.ViewModels.ApplicationWindowSettings.Initializers.Models.Interfaces;
using Application.Client.Windows.ApplicationWindow.Core.ViewModels.ApplicationWindowSettings.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.ApplicationWindow.Core.ViewModels.ApplicationWindowSettings.Initializers.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationWindowSettingsViewModelInitializer<TApplicationWindowSettingsViewModel, TApplicationWindowSettingsViewModelInitializerModel>(this IServiceCollection @this)
        where TApplicationWindowSettingsViewModel : IApplicationWindowSettingsViewModel
        where TApplicationWindowSettingsViewModelInitializerModel : IApplicationWindowSettingsViewModelInitializerModel
    {
        Type implementationInterfaceType = typeof(IApplicationWindowSettingsViewModelInitializer<TApplicationWindowSettingsViewModel, TApplicationWindowSettingsViewModelInitializerModel>);

        Type implementationType = Assembly.GetCallingAssembly().DefinedTypes
            .Where(x => x.IsClass)
            .Where(x => !x.IsAbstract)
            .Single(x => x.GetInterfaces().Any(y => y == implementationInterfaceType && y.IsGenericType));

        @this.AddTransient(implementationInterfaceType, implementationType);

        return @this;
    }
}