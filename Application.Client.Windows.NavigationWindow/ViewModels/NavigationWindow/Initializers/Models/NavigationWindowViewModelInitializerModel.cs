﻿using Application.Client.Windows.Core.ViewModels.Window.Initializer.Models;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Initializers.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindowSettings.Initializers.Models.Interfaces;

namespace Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Initializers.Models;

public class NavigationWindowViewModelInitializerModel<TNavigationWindowSettingsViewModelInitializerModel> : 
    WindowViewModelInitializerModel<TNavigationWindowSettingsViewModelInitializerModel>, INavigationWindowViewModelInitializerModel 
        where TNavigationWindowSettingsViewModelInitializerModel : INavigationWindowSettingsViewModelInitializerModel
{ }