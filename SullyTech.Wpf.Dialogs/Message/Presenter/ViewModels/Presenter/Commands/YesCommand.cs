using SullyTech.Wpf.Controls.Presenter.Core.Commands.Abstractions;
using SullyTech.Wpf.Controls.Window.Dialog.Services.DialogWindow.Interfaces;
using SullyTech.Wpf.Dialogs.Message.Window.Results;
using SullyTech.Wpf.Dialogs.Message.Window.Results.Enums;
using SullyTech.Wpf.Dialogs.Message.Window.UserControls;

namespace SullyTech.Wpf.Dialogs.Message.Presenter.ViewModels.Presenter.Commands;

public sealed class YesCommand : AsyncCommand<MessageDialogPresenterViewModel>
{
    private readonly IDialogWindowService _dialogWindowService;

    public YesCommand(MessageDialogPresenterViewModel callerViewModel, IDialogWindowService dialogWindowService) : base(callerViewModel)
    {
        _dialogWindowService = dialogWindowService;
    }

    public override async Task ExecuteAsync()
    {
        MessageDialogResult dialogResult = new() { ResultType = ResultType.Yes };

        _dialogWindowService.SetDialogResult<MessageDialogWindow, MessageDialogResult>(CallerViewModel.WindowId, dialogResult);

        await Task.CompletedTask;
    }
}