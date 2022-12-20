using SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindowSettings.Interfaces;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.Initializers.WindowSettings;

internal sealed class MessageDialogWindowSettingsViewModelInitializer : 
    IDialogWindowSettingsViewModelInitializer<IMessageDialogWindowSettingsViewModel, IMessageDialogWindowSettingsViewModelInitializerModel>
{
    public void Initialize(IMessageDialogWindowSettingsViewModel windowSettingsViewModel, IMessageDialogWindowSettingsViewModelInitializerModel windowSettingsViewModelInitializerModel)
    {
        windowSettingsViewModel.Title = windowSettingsViewModelInitializerModel.Title;
    }
}