﻿using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.WindowResults.MessageBox;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.WindowResults.MessageBox.Enums;
using SullyTech.Wpf.Windows.Core.Presenter.Commands.Abstractions;
using SullyTech.Wpf.Windows.Dialog.Services.CurrentDialogWindow.Interfaces;

namespace Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.Commands;

internal class CancelCommand : AsyncCommand<MessageBoxViewModel>
{
    private readonly ICurrentDialogWindowService _currentDialogWindowService;

    public CancelCommand(MessageBoxViewModel callerViewModel, ICurrentDialogWindowService currentDialogWindowService) : base(callerViewModel)
    {
        _currentDialogWindowService = currentDialogWindowService;
    }

    public override async Task ExecuteAsync()
    {
        MessageBoxWindowResult windowResult = new() { MessageBoxResult = MessageBoxResult.Cancel };

        await _currentDialogWindowService.SetDialogResultAsync(windowResult);
        await _currentDialogWindowService.CloseWindowAsync();
    }
}