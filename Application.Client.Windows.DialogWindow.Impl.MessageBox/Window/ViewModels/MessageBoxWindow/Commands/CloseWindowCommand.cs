using Application.Client.Windows.Core.Commands.Abstractions;
using Application.Client.Windows.DialogWindow.Core.Window.Interfaces;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.WindowResults.MessageBox;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.WindowResults.MessageBox.Enums;

namespace Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.ViewModels.MessageBoxWindow.Commands;

internal class CloseWindowCommand : AsyncWindowCommand<MessageBoxWindowViewModel, IDialogWindow>
{
    public CloseWindowCommand(MessageBoxWindowViewModel callerViewModel) : base(callerViewModel)
    { }

    public override async Task ExecuteAsync(IDialogWindow window)
    {
        if (window.DialogResult.HasValue == false)
        {
            CallerViewModel.CustomDialogResult = new MessageBoxWindowResult { MessageBoxResult = MessageBoxResult.None };
            window.DialogResult = false;
        }

        await Task.CompletedTask;
    }
}