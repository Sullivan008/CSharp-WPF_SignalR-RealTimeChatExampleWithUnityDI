﻿using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindowSettings.Initializers.Models.Interfaces;
using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindowSettings.Interfaces;
using Application.Client.Windows.Core.ViewModels.WindowSettings.Initializer.Interfaces;

namespace Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindowSettings.Initializers.Interfaces;

public interface IApplicationWindowSettingsViewModelInitializer<in TApplicationWindowSettingsViewModel, in TApplicationWindowSettingsViewModelInitializerModel> : 
    IWindowSettingsViewModelInitializer<TApplicationWindowSettingsViewModel, TApplicationWindowSettingsViewModelInitializerModel> 
        where TApplicationWindowSettingsViewModel : IApplicationWindowSettingsViewModel
        where TApplicationWindowSettingsViewModelInitializerModel : IApplicationWindowSettingsViewModelInitializerModel
{ }