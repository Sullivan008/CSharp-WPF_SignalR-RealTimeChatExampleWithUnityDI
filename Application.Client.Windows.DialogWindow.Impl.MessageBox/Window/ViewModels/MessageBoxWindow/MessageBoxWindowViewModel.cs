using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.ViewModels.MessageBoxWindow.Commands;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.ViewModels.MessageBoxWindowSettings;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.WindowResults.MessageBox;
using SullyTech.Wpf.Windows.Dialog.ViewModels.DialogWindow;

namespace Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.ViewModels.MessageBoxWindow;

public class MessageBoxWindowViewModel : DialogWindowViewModel<MessageBoxWindowSettingsViewModel, MessageBoxWindowResult>
{
    public MessageBoxWindowViewModel()
    {
        CloseWindowCommand = new CloseWindowCommand(this);
    }
}