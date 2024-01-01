using SullyTech.Wpf.Controls.Presenter.Core.Commands.Abstractions;
using SullyTech.Wpf.Controls.Window.Dialog.Services.DialogWindow.Interfaces;
using SullyTech.Wpf.Dialogs.Message.Window.Results;
using SullyTech.Wpf.Dialogs.Message.Window.Results.Enums;
using SullyTech.Wpf.Dialogs.Message.Window.UserControls;

namespace SullyTech.Wpf.Dialogs.Message.Presenter.ViewModels.Presenter.Commands;

internal sealed class OkCommand : AsyncCommand<MessageDialogPresenterViewModel>
{
    private readonly IDialogWindowService _dialogWindowService;

    public OkCommand(MessageDialogPresenterViewModel callerViewModel, IDialogWindowService dialogWindowService) : base(callerViewModel)
    {
        _dialogWindowService = dialogWindowService;
    }

    public override async Task ExecuteAsync()
    {
        MessageDialogResult dialogResult = new() { ResultType = ResultType.Ok };

        _dialogWindowService.SetDialogResult<MessageDialogWindow, MessageDialogResult>(CallerViewModel.WindowId, dialogResult);

        await Task.CompletedTask;
    }
}