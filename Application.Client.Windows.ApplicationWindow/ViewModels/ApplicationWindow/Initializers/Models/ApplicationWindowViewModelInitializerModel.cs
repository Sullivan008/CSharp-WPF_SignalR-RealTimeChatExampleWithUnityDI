﻿using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Initializers.Models.Interfaces;
using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindowSettings.Initializers.Models.Interfaces;
using Application.Client.Windows.Core.ViewModels.Window.Initializer.Models;

namespace Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Initializers.Models;

public class ApplicationWindowViewModelInitializerModel<TApplicationWindowSettingsViewModelInitializerModel> :
    WindowViewModelInitializerModel<TApplicationWindowSettingsViewModelInitializerModel>, IApplicationWindowViewModelInitializerModel
        where TApplicationWindowSettingsViewModelInitializerModel : IApplicationWindowSettingsViewModelInitializerModel
{ }