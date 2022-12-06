using SullyTech.Wpf.Dialogs.MessageDialog.Result;
using SullyTech.Wpf.Dialogs.MessageDialog.Result.Enums;
using SullyTech.Wpf.Windows.Core.Presenter.Commands.Abstractions;
using SullyTech.Wpf.Windows.Dialog.Services.CurrentDialogWindow.Interfaces;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Presenter.Views.MessageDialog.ViewModels.Presenter.Commands;

internal sealed class OkCommand : AsyncCommand<MessageDialogViewModel>
{
    private readonly ICurrentDialogWindowService _currentDialogWindowService;

    public OkCommand(MessageDialogViewModel callerViewModel, ICurrentDialogWindowService currentDialogWindowService) : base(callerViewModel)
    {
        _currentDialogWindowService = currentDialogWindowService;
    }

    public override async Task ExecuteAsync()
    {
        MessageDialogResult dialogResult = new() { ResultType = ResultType.Ok };

        await _currentDialogWindowService.SetDialogResultAsync(dialogResult);
        await _currentDialogWindowService.CloseWindowAsync();
    }
}