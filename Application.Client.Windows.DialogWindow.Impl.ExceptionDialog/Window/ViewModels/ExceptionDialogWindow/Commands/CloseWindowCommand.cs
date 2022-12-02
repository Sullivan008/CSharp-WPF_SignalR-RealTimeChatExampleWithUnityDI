using Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.WindowResults.ExceptionDialog;
using Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.WindowResults.ExceptionDialog.Enums;
using SullyTech.Wpf.Windows.Core.Commands.Abstractions;
using SullyTech.Wpf.Windows.Dialog.Window.Interfaces;

namespace Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.ViewModels.ExceptionDialogWindow.Commands;

internal class CloseWindowCommand : AsyncCommand<ExceptionDialogWindowViewModel, IDialogWindow>
{
    public CloseWindowCommand(ExceptionDialogWindowViewModel callerViewModel) : base(callerViewModel)
    { }

    public override async Task ExecuteAsync(IDialogWindow window)
    {
        if (window.DialogResult.HasValue == false)
        {
            CallerViewModel.DialogResult = new ExceptionDialogWindowResult { ExceptionDialogResult = ExceptionDialogResult.None };
            window.DialogResult = false;
        }

        await Task.CompletedTask;
    }
}