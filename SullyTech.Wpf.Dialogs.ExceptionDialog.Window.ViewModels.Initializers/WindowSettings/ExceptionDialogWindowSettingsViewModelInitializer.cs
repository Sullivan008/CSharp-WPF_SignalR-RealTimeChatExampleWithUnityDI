using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindowSettings.Interfaces;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Initializers.WindowSettings;

internal sealed class ExceptionDialogWindowSettingsViewModelInitializer : 
    IDialogWindowSettingsViewModelInitializer<IExceptionDialogWindowSettingsViewModel, IExceptionDialogWindowSettingsViewModelInitializerModel>
{
    public void Initialize(IExceptionDialogWindowSettingsViewModel windowSettingsViewModel, IExceptionDialogWindowSettingsViewModelInitializerModel windowSettingsViewModelInitializerModel)
    {
        windowSettingsViewModel.Title = windowSettingsViewModelInitializerModel.Title;
    }
}