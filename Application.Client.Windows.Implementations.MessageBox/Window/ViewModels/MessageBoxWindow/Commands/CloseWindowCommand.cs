using Application.Client.Windows.Core.Commands.Abstractions;
using Application.Client.Windows.DialogWindow.Window.Interfaces;
using Application.Client.Windows.Implementations.MessageBox.Window.WindowResults.MessageBox;
using Application.Client.Windows.Implementations.MessageBox.Window.WindowResults.MessageBox.Enums;

namespace Application.Client.Windows.Implementations.MessageBox.Window.ViewModels.MessageBoxWindow.Commands;

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