using Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.WindowResults.ExceptionDialog;
using Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.WindowResults.ExceptionDialog.Enums;
using SullyTech.Wpf.Windows.Core.Presenter.Commands.Abstractions;
using SullyTech.Wpf.Windows.Dialog.Services.CurrentDialogWindow.Interfaces;

namespace Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog.Commands;

internal class OkCommand : AsyncCommand<ExceptionDialogViewModel>
{
    private readonly ICurrentDialogWindowService _currentWindowService;

    public OkCommand(ExceptionDialogViewModel callerViewModel, ICurrentDialogWindowService currentWindowService) : base(callerViewModel)
    {
        _currentWindowService = currentWindowService;
    }

    public override async Task ExecuteAsync()
    {
        ExceptionDialogWindowResult windowResult = new() { ExceptionDialogResult = ExceptionDialogResult.Ok };

        await _currentWindowService.SetDialogResultAsync(windowResult);
        await _currentWindowService.CloseWindowAsync();
    }
}