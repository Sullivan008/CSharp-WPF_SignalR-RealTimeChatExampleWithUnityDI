using Application.Client.Windows.Core.Commands.Abstractions;
using Application.Client.Windows.DialogWindow.Window.Interfaces;
using Application.Client.Windows.Implementations.ExceptionDialog.Window.WindowResults.ExceptionDialog;
using Application.Client.Windows.Implementations.ExceptionDialog.Window.WindowResults.ExceptionDialog.Enums;

namespace Application.Client.Windows.Implementations.ExceptionDialog.Window.ViewModels.ExceptionDialogWindow.Commands;

internal class CloseWindowCommand : AsyncWindowCommand<ExceptionDialogWindowViewModel, IDialogWindow>
{
    public CloseWindowCommand(ExceptionDialogWindowViewModel callerViewModel) : base(callerViewModel)
    { }

    public override async Task ExecuteAsync(IDialogWindow window)
    {
        if (window.DialogResult.HasValue == false)
        {
            CallerViewModel.CustomDialogResult = new ExceptionDialogWindowResult { ExceptionDialogResult = ExceptionDialogResult.None };
            window.DialogResult = false;
        }

        await Task.CompletedTask;
    }
}