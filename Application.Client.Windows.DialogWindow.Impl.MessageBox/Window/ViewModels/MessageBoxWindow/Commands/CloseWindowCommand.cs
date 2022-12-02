using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.WindowResults.MessageBox;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.WindowResults.MessageBox.Enums;
using SullyTech.Wpf.Windows.Core.Commands.Abstractions;
using SullyTech.Wpf.Windows.Dialog.Window.Interfaces;

namespace Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.ViewModels.MessageBoxWindow.Commands;

internal class CloseWindowCommand : AsyncCommand<MessageBoxWindowViewModel, IDialogWindow>
{
    public CloseWindowCommand(MessageBoxWindowViewModel callerViewModel) : base(callerViewModel)
    { }

    public override async Task ExecuteAsync(IDialogWindow window)
    {
        if (window.DialogResult.HasValue == false)
        {
            CallerViewModel.DialogResult = new MessageBoxWindowResult { MessageBoxResult = MessageBoxResult.None };
            window.DialogResult = false;
        }

        await Task.CompletedTask;
    }
}