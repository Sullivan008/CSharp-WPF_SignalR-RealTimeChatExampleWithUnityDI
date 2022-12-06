using SullyTech.Wpf.Dialogs.MessageDialog.Result;
using SullyTech.Wpf.Dialogs.MessageDialog.Result.Enums;
using SullyTech.Wpf.Windows.Core.Commands.Abstractions;
using SullyTech.Wpf.Windows.Dialog.Window.Interfaces;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.Window.Commands;

internal sealed class CloseWindowCommand : AsyncCommand<MessageDialogWindowViewModel, IDialogWindow>
{
    public CloseWindowCommand(MessageDialogWindowViewModel callerViewModel) : base(callerViewModel)
    { }

    public override async Task ExecuteAsync(IDialogWindow window)
    {
        if (window.DialogResult.HasValue == false)
        {
            CallerViewModel.DialogResult = new MessageDialogResult { ResultType = ResultType.None };
            window.DialogResult = false;
        }

        await Task.CompletedTask;
    }
}