﻿using SullyTech.Wpf.Dialogs.MessageDialog.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Dialogs.MessageDialog.Result;
using SullyTech.Wpf.Dialogs.MessageDialog.Result.Enums;
using SullyTech.Wpf.Windows.Core.Presenter.Commands.Abstractions;
using SullyTech.Wpf.Windows.Dialog.Services.DialogWindow.Interfaces;
using SullyTech.Wpf.Windows.Dialog.Window.Interfaces;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Presenter.Commands.Presenter;

public sealed class OkCommand : AsyncCommand<IMessageDialogViewModel>
{
    private readonly IDialogWindowService _dialogWindowService;

    public OkCommand(IMessageDialogViewModel callerViewModel, IDialogWindowService dialogWindowService) : base(callerViewModel)
    {
        _dialogWindowService = dialogWindowService;
    }

    public override async Task ExecuteAsync()
    {
        IDialogWindow presenterWindow = await GetPresenterWindow();

        MessageDialogResult dialogResult = new() { ResultType = ResultType.Ok };

        await _dialogWindowService.SetDialogResult(presenterWindow, dialogResult);
        await _dialogWindowService.CloseWindowAsync(presenterWindow);
    }

    private async Task<IDialogWindow> GetPresenterWindow()
    {
        return await _dialogWindowService.GetWindowAsync(CallerViewModel.PresenterWindowId);
    }
}