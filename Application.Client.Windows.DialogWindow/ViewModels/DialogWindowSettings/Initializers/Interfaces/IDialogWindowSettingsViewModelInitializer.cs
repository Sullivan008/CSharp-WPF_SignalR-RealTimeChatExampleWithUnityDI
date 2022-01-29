﻿using Application.Client.Windows.DialogWindow.ViewModels.DialogWindowSettings.Initializers.Models.Interfaces;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindowSettings.Interfaces;

namespace Application.Client.Windows.DialogWindow.ViewModels.DialogWindowSettings.Initializers.Interfaces;

public interface IDialogWindowSettingsViewModelInitializer<in TDialogWindowSettingsViewModel, in TDialogWindowSettingsViewModelInitializerModel>
    where TDialogWindowSettingsViewModel : IDialogWindowSettingsViewModel
    where TDialogWindowSettingsViewModelInitializerModel : IDialogWindowSettingsViewModelInitializerModel
{
    public void Initialize(TDialogWindowSettingsViewModel dialogWindowSettingsViewModel, TDialogWindowSettingsViewModelInitializerModel dialogWindowSettingsViewModelInitializerModel);
}