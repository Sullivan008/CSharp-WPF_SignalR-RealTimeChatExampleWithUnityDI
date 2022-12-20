﻿using SullyTech.Wpf.Windows.Simple.Services.SimpleWindow.MethodParameters.WindowShowOptions.Interfaces;
using SullyTech.Wpf.Windows.Simple.ViewModels.Initializers.SimpleWindow.Models.Interfaces;
using SullyTech.Wpf.Windows.Simple.ViewModels.Initializers.SimpleWindowSettings.Models.Interfaces;
using SullyTech.Wpf.Windows.Simple.ViewModels.Interfaces.SimpleWindow;
using SullyTech.Wpf.Windows.Simple.ViewModels.Interfaces.SimpleWindowSettings;
using SullyTech.Wpf.Windows.Simple.Window.Interfaces;

namespace SullyTech.Wpf.Windows.Simple.Services.SimpleWindow.MethodParameters.WindowShowOptions;

public sealed class SimpleWindowShowOptions<TISimpleWindow, TISimpleWindowViewModel, TISimpleWindowSettingsViewModel> : ISimpleWindowShowOptions
    where TISimpleWindow : ISimpleWindow
    where TISimpleWindowViewModel : ISimpleWindowViewModel
    where TISimpleWindowSettingsViewModel : ISimpleWindowSettingsViewModel
{
    Type ISimpleWindowShowOptions.WindowType => typeof(TISimpleWindow);

    Type ISimpleWindowShowOptions.WindowViewModelType => typeof(TISimpleWindowViewModel);

    Type ISimpleWindowShowOptions.WindowSettingsViewModelType => typeof(TISimpleWindowSettingsViewModel);

    Type? ISimpleWindowShowOptions.WindowViewModelInitializerModelType =>
        WindowViewModelInitializerModel?.GetType()
            .GetInterfaces()
            .Single(x => !x.IsClass &&
                         x.IsInterface &&
                         x.IsAssignableTo(typeof(ISimpleWindowViewModelInitializerModel)) &&
                         x != typeof(ISimpleWindowViewModelInitializerModel));

    Type? ISimpleWindowShowOptions.WindowSettingsViewModelInitializerModelType =>
        WindowSettingsViewModelInitializerModel?.GetType()
            .GetInterfaces()
            .Single(x => !x.IsClass &&
                         x.IsInterface &&
                         x.IsAssignableTo(typeof(ISimpleWindowSettingsViewModelInitializerModel)) &&
                         x != typeof(ISimpleWindowSettingsViewModelInitializerModel));

    ISimpleWindowViewModelInitializerModel? ISimpleWindowShowOptions.WindowViewModelInitializerModel => WindowViewModelInitializerModel;

    ISimpleWindowSettingsViewModelInitializerModel? ISimpleWindowShowOptions.WindowSettingsViewModelInitializerModel => WindowSettingsViewModelInitializerModel;

    public ISimpleWindowViewModelInitializerModel? WindowViewModelInitializerModel { get; init; }

    public ISimpleWindowSettingsViewModelInitializerModel? WindowSettingsViewModelInitializerModel { get; init; }
}