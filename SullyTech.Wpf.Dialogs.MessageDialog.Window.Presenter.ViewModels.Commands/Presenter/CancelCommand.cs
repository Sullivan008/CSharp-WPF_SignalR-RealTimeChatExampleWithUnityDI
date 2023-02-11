using SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.Result;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.Result.Enums;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Commands.Abstractions;
using SullyTech.Wpf.Windows.Dialog.Window.Interfaces;
using SullyTech.Wpf.Windows.Dialog.Window.Services.DialogWindow.Interfaces;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Commands.Presenter;

public sealed class CancelCommand : AsyncCommand<IMessageDialogViewModel>
{
    private readonly IDialogWindowService _dialogWindowService;

    public CancelCommand(IMessageDialogViewModel callerViewModel, IDialogWindowService dialogWindowService) : base(callerViewModel)
    {
        _dialogWindowService = dialogWindowService;
    }

    public override async Task ExecuteAsync()
    {
        IDialogWindow presenterWindow = await GetPresenterWindow();

        MessageDialogResult dialogResult = new() { ResultType = ResultType.Cancel };

        await _dialogWindowService.SetDialogResult(presenterWindow, dialogResult);
        await _dialogWindowService.CloseWindowAsync(presenterWindow);
    }

    private async Task<IDialogWindow> GetPresenterWindow()
    {
        return await _dialogWindowService.GetWindowAsync(CallerViewModel.PresenterWindowId);
    }
}