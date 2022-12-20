using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindowSettings.Interfaces;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindowSettings.Models.Interfaces;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Interfaces.DialogWindowSettings;

namespace SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindowSettings.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddDialogWindowSettingsViewModelInitializer<TIDialogWindowSettingsViewModel, TIDialogWindowSettingsViewModelInitializerModel>(this IServiceCollection @this)
        where TIDialogWindowSettingsViewModel : IDialogWindowSettingsViewModel
        where TIDialogWindowSettingsViewModelInitializerModel : IDialogWindowSettingsViewModelInitializerModel
    {
        Type implementationInterfaceType = 
            typeof(IDialogWindowSettingsViewModelInitializer<TIDialogWindowSettingsViewModel, TIDialogWindowSettingsViewModelInitializerModel>);

        Type implementationType = Assembly.GetCallingAssembly().DefinedTypes.Where(x => x.IsClass)
                                                                            .Where(x => !x.IsAbstract)
                                                                            .Single(x => x.GetInterfaces().Any(y => y == implementationInterfaceType && y.IsGenericType));

        @this.AddTransient(implementationInterfaceType, implementationType);
    }
}