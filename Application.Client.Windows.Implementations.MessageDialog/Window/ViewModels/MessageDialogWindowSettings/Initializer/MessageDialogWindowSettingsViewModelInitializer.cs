using Application.Client.Windows.DialogWindow.ViewModels.DialogWindowSettings.Initializers.Interfaces;
using Application.Client.Windows.Implementations.MessageDialog.Window.ViewModels.MessageDialogWindowSettings.Initializer.Models;

namespace Application.Client.Windows.Implementations.MessageDialog.Window.ViewModels.MessageDialogWindowSettings.Initializer;

public class MessageDialogWindowSettingsViewModelInitializer : IDialogWindowSettingsViewModelInitializer<MessageDialogWindowSettingsViewModel, MessageDialogWindowSettingsViewModelInitializerModel>
{
    public void Initialize(MessageDialogWindowSettingsViewModel windowSettingsViewModel, MessageDialogWindowSettingsViewModelInitializerModel windowSettingsViewModelInitializerModel)
    {
        windowSettingsViewModel.Title = windowSettingsViewModelInitializerModel.Title;
    }
}