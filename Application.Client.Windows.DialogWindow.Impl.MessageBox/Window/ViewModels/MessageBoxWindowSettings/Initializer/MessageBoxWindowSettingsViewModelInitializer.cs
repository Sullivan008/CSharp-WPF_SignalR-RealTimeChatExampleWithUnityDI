using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.ViewModels.MessageBoxWindowSettings.Initializer.Models;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindowSettings.Interfaces;

namespace Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.ViewModels.MessageBoxWindowSettings.Initializer;

public class MessageBoxWindowSettingsViewModelInitializer : IDialogWindowSettingsViewModelInitializer<MessageBoxWindowSettingsViewModel, MessageBoxWindowSettingsViewModelInitializerModel>
{
    public void Initialize(MessageBoxWindowSettingsViewModel windowSettingsViewModel, MessageBoxWindowSettingsViewModelInitializerModel windowSettingsViewModelInitializerModel)
    {
        windowSettingsViewModel.Title = windowSettingsViewModelInitializerModel.Title;
    }
}