﻿using SullyTech.Wpf.Windows.Dialog.Services.DialogWindow.MethodParameters.WindowShowOptions.Interfaces;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindow.Models.Interfaces;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindowSettings.Models.Interfaces;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Interfaces.DialogWindow;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Interfaces.DialogWindowSettings;
using SullyTech.Wpf.Windows.Dialog.Window.Interfaces;

namespace SullyTech.Wpf.Windows.Dialog.Services.DialogWindow.MethodParameters.WindowShowOptions;

public class DialogWindowShowOptions<TIDialogWindow, TIDialogWindowViewModel, TIDialogWindowSettingsViewModel> : IDialogWindowShowOptions
    where TIDialogWindow : IDialogWindow
    where TIDialogWindowViewModel : IDialogWindowViewModel
    where TIDialogWindowSettingsViewModel : IDialogWindowSettingsViewModel
{
    Type IDialogWindowShowOptions.WindowType => typeof(TIDialogWindow);

    Type IDialogWindowShowOptions.WindowViewModelType => typeof(TIDialogWindowViewModel);

    Type IDialogWindowShowOptions.WindowSettingsViewModelType => typeof(TIDialogWindowSettingsViewModel);

    Type? IDialogWindowShowOptions.WindowViewModelInitializerModelType =>
        WindowViewModelInitializerModel?.GetType()
            .GetInterfaces()
            .Single(x => !x.IsClass &&
                         x.IsInterface &&
                         x.IsAssignableTo(typeof(IDialogWindowViewModelInitializerModel)) &&
                         x != typeof(IDialogWindowViewModelInitializerModel));

    Type? IDialogWindowShowOptions.WindowSettingsViewModelInitializerModelType =>
        WindowSettingsViewModelInitializerModel?.GetType()
            .GetInterfaces()
            .Single(x => !x.IsClass &&
                         x.IsInterface &&
                         x.IsAssignableTo(typeof(IDialogWindowSettingsViewModelInitializerModel)) &&
                         x != typeof(IDialogWindowSettingsViewModelInitializerModel));

    IDialogWindowViewModelInitializerModel? IDialogWindowShowOptions.WindowViewModelInitializerModel => WindowViewModelInitializerModel;

    IDialogWindowSettingsViewModelInitializerModel? IDialogWindowShowOptions.WindowSettingsViewModelInitializerModel => WindowSettingsViewModelInitializerModel;

    public IDialogWindowViewModelInitializerModel? WindowViewModelInitializerModel { get; init; }

    public IDialogWindowSettingsViewModelInitializerModel? WindowSettingsViewModelInitializerModel { get; init; }
}