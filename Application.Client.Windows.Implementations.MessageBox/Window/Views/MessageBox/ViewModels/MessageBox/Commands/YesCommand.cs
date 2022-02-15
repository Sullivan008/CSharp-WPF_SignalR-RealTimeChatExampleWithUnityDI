using Application.Client.Windows.Core.ContentPresenter.Commands.Abstractions;
using Application.Client.Windows.DialogWindow.Services.CurrentDialogWindow.Interfaces;
using Application.Client.Windows.Implementations.MessageBox.Window.WindowResults.MessageBox;
using Application.Client.Windows.Implementations.MessageBox.Window.WindowResults.MessageBox.Enums;

namespace Application.Client.Windows.Implementations.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.Commands;

internal class YesCommand : AsyncContentPresenterCommand<MessageBoxViewModel>
{
    private readonly ICurrentDialogWindowService _currentDialogWindowService;

    public YesCommand(MessageBoxViewModel callerViewModel, ICurrentDialogWindowService currentDialogWindowService) : base(callerViewModel)
    {
        _currentDialogWindowService = currentDialogWindowService;
    }

    public override async Task ExecuteAsync()
    {
        MessageBoxWindowResult windowResult = new() { MessageBoxResult = MessageBoxResult.Yes };

        await _currentDialogWindowService.SetCustomDialogWindowResult(windowResult);
        await _currentDialogWindowService.CloseWindow();
    }
}