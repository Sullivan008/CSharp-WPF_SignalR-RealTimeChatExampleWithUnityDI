using Application.Client.Windows.Core.ContentPresenter.Commands.Abstractions;
using Application.Client.Windows.DialogWindow.Core.Services.CurrentDialogWindow.Interfaces;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.WindowResults.MessageBox;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.WindowResults.MessageBox.Enums;

namespace Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.Commands;

internal class OkCommand : AsyncContentPresenterCommand<MessageBoxViewModel>
{
    private readonly ICurrentDialogWindowService _currentDialogWindowService;

    public OkCommand(MessageBoxViewModel callerViewModel, ICurrentDialogWindowService currentDialogWindowService) : base(callerViewModel)
    {
        _currentDialogWindowService = currentDialogWindowService;
    }

    public override async Task ExecuteAsync()
    {
        MessageBoxWindowResult windowResult = new() { MessageBoxResult = MessageBoxResult.Ok };

        await _currentDialogWindowService.SetCustomDialogWindowResult(windowResult);
        await _currentDialogWindowService.CloseWindow();
    }
}