using System.Reflection;
using Application.Client.Windows.DialogWindow.Core.ViewModels.DialogWindowSettings.Initializers.Interfaces;
using Application.Client.Windows.DialogWindow.Core.ViewModels.DialogWindowSettings.Initializers.Models.Interfaces;
using Application.Client.Windows.DialogWindow.Core.ViewModels.DialogWindowSettings.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.DialogWindow.Core.ViewModels.DialogWindowSettings.Initializers.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDialogWindowSettingsViewModelInitializer<TDialogWindowSettingsViewModel, TDialogWindowSettingsViewModelInitializerModel>(this IServiceCollection @this)
        where TDialogWindowSettingsViewModel : IDialogWindowSettingsViewModel
        where TDialogWindowSettingsViewModelInitializerModel : IDialogWindowSettingsViewModelInitializerModel
    {
        Type implementationInterfaceType = typeof(IDialogWindowSettingsViewModelInitializer<TDialogWindowSettingsViewModel, TDialogWindowSettingsViewModelInitializerModel>);

        Type implementationType = Assembly.GetCallingAssembly().DefinedTypes
            .Where(x => x.IsClass)
            .Where(x => !x.IsAbstract)
            .Single(x => x.GetInterfaces().Any(y => y == implementationInterfaceType && y.IsGenericType));

        @this.AddTransient(implementationInterfaceType, implementationType);

        return @this;
    }
}