using Application.Client.Windows.DialogWindow.ViewModels.DialogWindow;
using Application.Client.Windows.Implementations.MessageBox.Window.ViewModels.MessageBoxWindow.Commands;
using Application.Client.Windows.Implementations.MessageBox.Window.ViewModels.MessageBoxWindowSettings;
using Application.Client.Windows.Implementations.MessageBox.Window.WindowResults.MessageBox;

namespace Application.Client.Windows.Implementations.MessageBox.Window.ViewModels.MessageBoxWindow;

public class MessageBoxWindowViewModel : DialogWindowViewModel<MessageBoxWindowSettingsViewModel, MessageBoxWindowResult>
{
    public MessageBoxWindowViewModel()
    {
        CloseWindowCommand = new CloseWindowCommand(this);
    }
}