using SullyTech.Wpf.Dialogs.MessageDialog.Result;
using SullyTech.Wpf.Dialogs.MessageDialog.Result.Enums;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.Interfaces;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Windows.Core.Commands.Abstractions;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Window.Commands.Window;

public sealed class CloseWindowCommand : AsyncCommand<IMessageDialogWindowViewModel, IMessageDialogWindow>
{
    public CloseWindowCommand(IMessageDialogWindowViewModel callerViewModel) : base(callerViewModel)
    { }

    public override async Task ExecuteAsync(IMessageDialogWindow window)
    {
        if (window.DialogResult.HasValue == false)
        {
            CallerViewModel.DialogResult = new MessageDialogResult { ResultType = ResultType.None };
            window.DialogResult = false;
        }

        await Task.CompletedTask;
    }
}