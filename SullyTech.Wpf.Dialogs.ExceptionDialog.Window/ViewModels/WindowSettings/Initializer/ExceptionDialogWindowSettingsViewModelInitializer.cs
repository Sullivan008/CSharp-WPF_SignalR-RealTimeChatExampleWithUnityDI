using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.WindowSettings.Initializer.Models;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindowSettings.Interfaces;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.WindowSettings.Initializer;

internal sealed class ExceptionDialogWindowSettingsViewModelInitializer : IDialogWindowSettingsViewModelInitializer<ExceptionDialogWindowSettingsViewModel, ExceptionDialogWindowSettingsViewModelInitializerModel>
{
    public void Initialize(ExceptionDialogWindowSettingsViewModel windowSettingsViewModel, ExceptionDialogWindowSettingsViewModelInitializerModel windowSettingsViewModelInitializerModel)
    {
        windowSettingsViewModel.Title = windowSettingsViewModelInitializerModel.Title;
    }
}