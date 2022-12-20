using SullyTech.Wpf.Dialogs.ExceptionDialog.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Result;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Result.Enums;
using SullyTech.Wpf.Windows.Core.Presenter.Commands.Abstractions;
using SullyTech.Wpf.Windows.Dialog.Services.DialogWindow.Interfaces;
using SullyTech.Wpf.Windows.Dialog.Window.Interfaces;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Presenter.Commands.Presenter;

public sealed class OkCommand : AsyncCommand<IExceptionDialogViewModel>
{
    private readonly IDialogWindowService _dialogWindowService;

    public OkCommand(IExceptionDialogViewModel callerViewModel, IDialogWindowService dialogWindowService) : base(callerViewModel)
    {
        _dialogWindowService = dialogWindowService;
    }

    public override async Task ExecuteAsync()
    {
        IDialogWindow presenterWindow = await GetPresenterWindow();

        ExceptionDialogResult dialogResult = new() { ResultType = ResultType.Ok };

        await _dialogWindowService.SetDialogResult(presenterWindow, dialogResult);
        await _dialogWindowService.CloseWindowAsync(presenterWindow);
    }

    private async Task<IDialogWindow> GetPresenterWindow()
    {
        return await _dialogWindowService.GetWindowAsync(CallerViewModel.PresenterWindowId);
    }
}