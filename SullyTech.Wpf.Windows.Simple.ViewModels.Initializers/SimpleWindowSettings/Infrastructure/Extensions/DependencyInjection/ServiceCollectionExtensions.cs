﻿using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Simple.ViewModels.Initializers.SimpleWindowSettings.Interfaces;
using SullyTech.Wpf.Windows.Simple.ViewModels.Initializers.SimpleWindowSettings.Models.Interfaces;
using SullyTech.Wpf.Windows.Simple.ViewModels.Interfaces.SimpleWindowSettings;

namespace SullyTech.Wpf.Windows.Simple.ViewModels.Initializers.SimpleWindowSettings.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddSimpleWindowSettingsViewModelInitializer<TSimpleWindowSettingsViewModel, TSimpleWindowSettingsViewModelInitializerModel>(this IServiceCollection @this)
        where TSimpleWindowSettingsViewModel : ISimpleWindowSettingsViewModel
        where TSimpleWindowSettingsViewModelInitializerModel : ISimpleWindowSettingsViewModelInitializerModel
    {
        Type implementationInterfaceType =
            typeof(ISimpleWindowSettingsViewModelInitializer<TSimpleWindowSettingsViewModel, TSimpleWindowSettingsViewModelInitializerModel>);

        Type implementationType =
            Assembly.GetCallingAssembly().DefinedTypes.Where(x => x.IsClass)
                                                      .Where(x => !x.IsAbstract)
                                                      .Single(x => x.GetInterfaces().Any(y => y == implementationInterfaceType && y.IsGenericType));

        @this.AddTransient(implementationInterfaceType, implementationType);
    }
}