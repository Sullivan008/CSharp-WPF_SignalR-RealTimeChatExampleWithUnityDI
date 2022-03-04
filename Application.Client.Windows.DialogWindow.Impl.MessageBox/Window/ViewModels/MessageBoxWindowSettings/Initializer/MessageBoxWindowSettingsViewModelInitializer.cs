using Application.Client.Windows.DialogWindow.Core.ViewModels.DialogWindowSettings.Initializers.Interfaces;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.ViewModels.MessageBoxWindowSettings.Initializer.Models;

namespace Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.ViewModels.MessageBoxWindowSettings.Initializer;

public class MessageBoxWindowSettingsViewModelInitializer : IDialogWindowSettingsViewModelInitializer<MessageBoxWindowSettingsViewModel, MessageBoxWindowSettingsViewModelInitializerModel>
{
    public void Initialize(MessageBoxWindowSettingsViewModel windowSettingsViewModel, MessageBoxWindowSettingsViewModelInitializerModel windowSettingsViewModelInitializerModel)
    {
        windowSettingsViewModel.Title = windowSettingsViewModelInitializerModel.Title;
    }
}