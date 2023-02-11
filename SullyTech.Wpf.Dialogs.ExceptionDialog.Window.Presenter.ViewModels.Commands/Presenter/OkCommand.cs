using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Result;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Result.Enums;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Commands.Abstractions;
using SullyTech.Wpf.Windows.Dialog.Window.Interfaces;
using SullyTech.Wpf.Windows.Dialog.Window.Services.DialogWindow.Interfaces;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Presenter.ViewModels.Commands.Presenter;

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