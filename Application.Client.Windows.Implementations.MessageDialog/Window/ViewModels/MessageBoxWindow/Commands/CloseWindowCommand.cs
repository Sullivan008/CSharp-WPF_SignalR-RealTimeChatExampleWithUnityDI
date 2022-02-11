using Application.Client.Common.Commands;
using Application.Client.Windows.DialogWindow.Window.Interfaces;
using Application.Client.Windows.Implementations.MessageBox.Window.WindowResults.MessageBox;
using Application.Client.Windows.Implementations.MessageBox.Window.WindowResults.MessageBox.Enums;

namespace Application.Client.Windows.Implementations.MessageBox.Window.ViewModels.MessageBoxWindow.Commands;

internal class CloseWindowCommand : AsyncCommandBase<MessageBoxWindowViewModel, IDialogWindow>
{
    public CloseWindowCommand(MessageBoxWindowViewModel callerViewModel) : base(callerViewModel)
    { }

    public override async Task ExecuteAsync(IDialogWindow window)
    {
        CallerViewModel.CustomDialogResult = new MessageBoxWindowResult { MessageBoxResult = MessageBoxResult.None };
        window.DialogResult = false;

        await Task.CompletedTask;
    }
}