using SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.WindowSettings.Initializer.Models;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindowSettings.Interfaces;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.WindowSettings.Initializer;

internal sealed class MessageDialogWindowSettingsViewModelInitializer : IDialogWindowSettingsViewModelInitializer<MessageDialogWindowSettingsViewModel, MessageDialogWindowSettingsViewModelInitializerModel>
{
    public void Initialize(MessageDialogWindowSettingsViewModel windowSettingsViewModel, MessageDialogWindowSettingsViewModelInitializerModel windowSettingsViewModelInitializerModel)
    {
        windowSettingsViewModel.Title = windowSettingsViewModelInitializerModel.Title;
    }
}