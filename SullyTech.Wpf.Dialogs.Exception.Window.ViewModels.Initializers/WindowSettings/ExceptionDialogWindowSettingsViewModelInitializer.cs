using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Initializers.WindowSettings.Interfaces;
using SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;
using SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Initializers.WindowSettings;

internal sealed class ExceptionDialogWindowSettingsViewModelInitializer : IDialogWindowSettingsViewModelInitializer<IExceptionDialogWindowSettingsViewModel, IExceptionDialogWindowSettingsViewModelInitializerModel>
{
    public void Initialize(IExceptionDialogWindowSettingsViewModel windowSettingsViewModel, IExceptionDialogWindowSettingsViewModelInitializerModel windowSettingsViewModelInitializerModel)
    {
        windowSettingsViewModel.Title = windowSettingsViewModelInitializerModel.Title;
    }
}