using SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.Result;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.Result.Enums;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Commands.Abstractions;
using SullyTech.Wpf.Windows.Dialog.Window.Interfaces;
using SullyTech.Wpf.Windows.Dialog.Window.Services.DialogWindow.Interfaces;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Commands.Presenter;

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

        await _dialogWindowService.SetDialogResultAsync(dialogWindow, dialogResult);
        await _dialogWindowService.CloseWindowAsync(dialogWindow);
    }

    private async Task<IDialogWindow> GetPresenterWindow()
    {
        return await _dialogWindowService.GetWindowAsync(CallerViewModel.PresenterWindowId);
    }
}