using Application.Client.Windows.DialogWindow.Core.ViewModels.DialogWindow.Initializers.Interfaces;
using Application.Client.Windows.DialogWindow.Core.ViewModels.DialogWindowSettings.Initializers.Interfaces;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.ViewModels.MessageBoxWindow.Initializer.Models;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.ViewModels.MessageBoxWindowSettings;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.ViewModels.MessageBoxWindowSettings.Initializer.Models;

namespace Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.ViewModels.MessageBoxWindow.Initializer;

public class MessageBoxWindowViewModelInitializer : IDialogWindowViewModelInitializer<MessageBoxWindowViewModel, MessageBoxWindowViewModelInitializerModel>
{
    private readonly IDialogWindowSettingsViewModelInitializer<MessageBoxWindowSettingsViewModel, MessageBoxWindowSettingsViewModelInitializerModel> _dialogWindowSettingsViewModelInitializer;

    public MessageBoxWindowViewModelInitializer(IDialogWindowSettingsViewModelInitializer<MessageBoxWindowSettingsViewModel, MessageBoxWindowSettingsViewModelInitializerModel> dialogWindowSettingsViewModelInitializer)
    {
        _dialogWindowSettingsViewModelInitializer = dialogWindowSettingsViewModelInitializer;
    }

    public void Initialize(MessageBoxWindowViewModel windowViewModel, MessageBoxWindowViewModelInitializerModel windowViewModelInitializerModel)
    {
        _dialogWindowSettingsViewModelInitializer.Initialize(windowViewModel.WindowSettings, windowViewModelInitializerModel.WindowSettings);
    }
}