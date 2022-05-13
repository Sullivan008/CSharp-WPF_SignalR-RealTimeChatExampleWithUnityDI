﻿using Application.Client.Windows.Core.ViewModels.WindowSettings.Initializer.Interfaces;
using Application.Client.Windows.DialogWindow.Core.ViewModels.DialogWindowSettings.Initializers.Models.Interfaces;
using Application.Client.Windows.DialogWindow.Core.ViewModels.DialogWindowSettings.Interfaces;

namespace Application.Client.Windows.DialogWindow.Core.ViewModels.DialogWindowSettings.Initializers.Interfaces;

public interface IDialogWindowSettingsViewModelInitializer<in TDialogWindowSettingsViewModel, in TDialogWindowSettingsViewModelInitializerModel> : 
    IWindowSettingsViewModelInitializer<TDialogWindowSettingsViewModel, TDialogWindowSettingsViewModelInitializerModel> 
        where TDialogWindowSettingsViewModel : IDialogWindowSettingsViewModel
        where TDialogWindowSettingsViewModelInitializerModel : IDialogWindowSettingsViewModelInitializerModel
{ }