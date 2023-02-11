﻿using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Interfaces;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Result;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Result.Enums;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Windows.Core.Window.ViewModels.Commands.Abstractions;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Commands.Window;

public sealed class CloseWindowCommand : AsyncCommand<IExceptionDialogWindowViewModel, IExceptionDialogWindow>
{
    public CloseWindowCommand(IExceptionDialogWindowViewModel callerViewModel) : base(callerViewModel)
    { }

    public override async Task ExecuteAsync(IExceptionDialogWindow window)
    {
        if (window.DialogResult.HasValue == false)
        {
            CallerViewModel.DialogResult = new ExceptionDialogResult { ResultType = ResultType.None };
            window.DialogResult = false;
        }

        await Task.CompletedTask;
    }
}