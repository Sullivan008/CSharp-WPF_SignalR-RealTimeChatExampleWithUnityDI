﻿using Application.Client.Windows.DialogWindow.Core.ViewModels.DialogWindow.Initializers.Interfaces;
using Application.Client.Windows.DialogWindow.Core.ViewModels.DialogWindowSettings.Initializers.Interfaces;
using Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.ViewModels.ExceptionDialogWindow.Initializer.Models;
using Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.ViewModels.ExceptionDialogWindowSettings;
using Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.ViewModels.ExceptionDialogWindowSettings.Initializer.Models;

namespace Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.ViewModels.ExceptionDialogWindow.Initializer;

public class ExceptionDialogWindowViewModelInitializer : IDialogWindowViewModelInitializer<ExceptionDialogWindowViewModel, ExceptionDialogWindowViewModelInitializerModel>
{
    private readonly IDialogWindowSettingsViewModelInitializer<ExceptionDialogWindowSettingsViewModel, ExceptionDialogWindowSettingsViewModelInitializerModel> _dialogWindowSettingsViewModelInitializer;

    public ExceptionDialogWindowViewModelInitializer(IDialogWindowSettingsViewModelInitializer<ExceptionDialogWindowSettingsViewModel, ExceptionDialogWindowSettingsViewModelInitializerModel> dialogWindowSettingsViewModelInitializer)
    {
        _dialogWindowSettingsViewModelInitializer = dialogWindowSettingsViewModelInitializer;
    }

    public void Initialize(ExceptionDialogWindowViewModel windowViewModel, ExceptionDialogWindowViewModelInitializerModel windowViewModelInitializerModel)
    {
        _dialogWindowSettingsViewModelInitializer.Initialize(windowViewModel.WindowSettings, windowViewModelInitializerModel.WindowSettings);
    }
}