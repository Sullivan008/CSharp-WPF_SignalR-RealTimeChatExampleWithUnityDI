﻿using Microsoft.Extensions.DependencyInjection;
using SullyTech.App.Client.Wpf.Windows.Main.ViewModels.Initializers.WindowSettings.Models.Interfaces;
using SullyTech.App.Client.Wpf.Windows.Main.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Windows.Navigation.ViewModels.Initializers.NavigationWindowSettings.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.App.Client.Wpf.Windows.Main.ViewModels.Initializers.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMainWindowSettingsViewModelInitializer(this IServiceCollection @this)
    {
        @this.AddNavigationWindowSettingsViewModelInitializer<IMainWindowSettingsViewModel, IMainWindowSettingsViewModelInitializerModel>();
    }
}