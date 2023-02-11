using SullyTech.Wpf.Dialogs.MessageDialog.Window.Interfaces;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.Result;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.Result.Enums;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Windows.Core.Window.ViewModels.Commands.Abstractions;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.Commands.Window;

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