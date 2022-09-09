using Application.Client.Windows.Core.ContentPresenter.Commands.Abstractions;
using Application.Client.Windows.DialogWindow.Core.Services.CurrentDialogWindow.Interfaces;
using Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.WindowResults.ExceptionDialog;
using Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.WindowResults.ExceptionDialog.Enums;

namespace Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog.Commands;

internal class OkCommand : AsyncContentPresenterCommand<ExceptionDialogViewModel>
{
    private readonly ICurrentDialogWindowService _currentDialogWindowService;

    public OkCommand(ExceptionDialogViewModel callerViewModel, ICurrentDialogWindowService currentDialogWindowService) : base(callerViewModel)
    {
        _currentDialogWindowService = currentDialogWindowService;
    }

    public override async Task ExecuteAsync()
    {
        ExceptionDialogWindowResult windowResult = new() { ExceptionDialogResult = ExceptionDialogResult.Ok };

        await _currentDialogWindowService.SetCustomDialogWindowResult(windowResult);
        await _currentDialogWindowService.CloseWindow();
    }
}