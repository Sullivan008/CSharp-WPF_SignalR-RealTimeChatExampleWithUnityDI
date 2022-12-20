using SullyTech.Wpf.Dialogs.MessageDialog.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Dialogs.MessageDialog.Result;
using SullyTech.Wpf.Dialogs.MessageDialog.Result.Enums;
using SullyTech.Wpf.Windows.Core.Presenter.Commands.Abstractions;
using SullyTech.Wpf.Windows.Dialog.Services.DialogWindow.Interfaces;
using SullyTech.Wpf.Windows.Dialog.Window.Interfaces;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Presenter.Commands.Presenter;

public sealed class YesCommand : AsyncCommand<IMessageDialogViewModel>
{
    private readonly IDialogWindowService _dialogWindowService;

    public YesCommand(IMessageDialogViewModel callerViewModel, IDialogWindowService dialogWindowService) : base(callerViewModel)
    {
        _dialogWindowService = dialogWindowService;
    }

    public override async Task ExecuteAsync()
    {
        IDialogWindow dialogWindow = await GetPresenterWindow();

        MessageDialogResult dialogResult = new() { ResultType = ResultType.Yes };

        await _dialogWindowService.SetDialogResult(dialogWindow, dialogResult);
        await _dialogWindowService.CloseWindowAsync(dialogWindow);
    }

    private async Task<IDialogWindow> GetPresenterWindow()
    {
        return await _dialogWindowService.GetWindowAsync(CallerViewModel.PresenterWindowId);
    }
}