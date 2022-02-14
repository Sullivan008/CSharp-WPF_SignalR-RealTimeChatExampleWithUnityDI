using Application.Client.Windows.DialogWindow.ViewModels.DialogWindowSettings.Initializers.Interfaces;
using Application.Client.Windows.Implementations.ExceptionDialog.Window.ViewModels.ExceptionDialogWindowSettings.Initializer.Models;

namespace Application.Client.Windows.Implementations.ExceptionDialog.Window.ViewModels.ExceptionDialogWindowSettings.Initializer;

public class ExceptionDialogWindowSettingsViewModelInitializer : IDialogWindowSettingsViewModelInitializer<ExceptionDialogWindowSettingsViewModel, ExceptionDialogWindowSettingsViewModelInitializerModel>
{
    public void Initialize(ExceptionDialogWindowSettingsViewModel windowSettingsViewModel, ExceptionDialogWindowSettingsViewModelInitializerModel windowSettingsViewModelInitializerModel)
    {
        windowSettingsViewModel.Title = windowSettingsViewModelInitializerModel.Title;
    }
}