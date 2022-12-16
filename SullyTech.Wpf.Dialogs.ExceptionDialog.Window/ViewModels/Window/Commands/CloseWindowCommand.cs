using SullyTech.Wpf.Dialogs.ExceptionDialog.Result;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Result.Enums;
using SullyTech.Wpf.Windows.Core.Commands.Abstractions;
using SullyTech.Wpf.Windows.Dialog.Window.Interfaces;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Window.Commands;

internal sealed class CloseWindowCommand : AsyncCommand<ExceptionDialogWindowViewModel, IDialogWindow>
{
    public CloseWindowCommand(ExceptionDialogWindowViewModel callerViewModel) : base(callerViewModel)
    { }

    public override async Task ExecuteAsync(IDialogWindow window)
    {
        if (window.DialogResult.HasValue == false)
        {
            CallerViewModel.DialogResult = new ExceptionDialogResult { ResultType = ResultType.None };
            window.DialogResult = false;
        }

        await Task.CompletedTask;
    }
}