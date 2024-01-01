using SullyTech.Wpf.Controls.Presenter.Core.Commands.Abstractions;
using SullyTech.Wpf.Controls.Window.Dialog.Services.DialogWindow.Interfaces;
using SullyTech.Wpf.Dialogs.Exception.Window.Results;
using SullyTech.Wpf.Dialogs.Exception.Window.Results.Enums;
using SullyTech.Wpf.Dialogs.Exception.Window.UserControls;

namespace SullyTech.Wpf.Dialogs.Exception.Presenter.ViewModels.Presenter.Commands;

internal sealed class OkCommand : AsyncCommand<ExceptionDialogPresenterViewModel>
{
    private readonly IDialogWindowService _dialogWindowService;

    public OkCommand(ExceptionDialogPresenterViewModel callerViewModel, IDialogWindowService dialogWindowService) : base(callerViewModel)
    {
        _dialogWindowService = dialogWindowService;
    }

    public override async Task ExecuteAsync()
    {
        ExceptionDialogResult dialogResult = new() { ResultType = ResultType.Ok };

        _dialogWindowService.SetDialogResult<ExceptionDialogWindow, ExceptionDialogResult>(CallerViewModel.WindowId, dialogResult);

        await Task.CompletedTask;
    }
}