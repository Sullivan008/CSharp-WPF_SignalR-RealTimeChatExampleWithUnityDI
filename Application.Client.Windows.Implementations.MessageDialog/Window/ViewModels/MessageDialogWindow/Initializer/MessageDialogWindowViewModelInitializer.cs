using Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Initializers.Interfaces;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindowSettings.Initializers.Interfaces;
using Application.Client.Windows.Implementations.MessageDialog.Window.ViewModels.MessageDialogWindow.Initializer.Models;
using Application.Client.Windows.Implementations.MessageDialog.Window.ViewModels.MessageDialogWindowSettings;
using Application.Client.Windows.Implementations.MessageDialog.Window.ViewModels.MessageDialogWindowSettings.Initializer.Models;

namespace Application.Client.Windows.Implementations.MessageDialog.Window.ViewModels.MessageDialogWindow.Initializer;

public class MessageDialogWindowViewModelInitializer : IDialogWindowViewModelInitializer<MessageDialogWindowViewModel, MessageDialogWindowViewModelInitializerModel>
{
    private readonly IDialogWindowSettingsViewModelInitializer<MessageDialogWindowSettingsViewModel, MessageDialogWindowSettingsViewModelInitializerModel> _dialogWindowSettingsViewModelInitializer;

    public MessageDialogWindowViewModelInitializer(IDialogWindowSettingsViewModelInitializer<MessageDialogWindowSettingsViewModel, MessageDialogWindowSettingsViewModelInitializerModel> dialogWindowSettingsViewModelInitializer)
    {
        _dialogWindowSettingsViewModelInitializer = dialogWindowSettingsViewModelInitializer;
    }

    public void Initialize(MessageDialogWindowViewModel windowViewModel, MessageDialogWindowViewModelInitializerModel windowViewModelInitializerModel)
    {
        _dialogWindowSettingsViewModelInitializer.Initialize(windowViewModel.WindowSettings, windowViewModelInitializerModel.WindowSettings);
    }
}