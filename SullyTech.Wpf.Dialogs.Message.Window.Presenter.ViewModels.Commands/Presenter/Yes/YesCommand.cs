using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Commands.Abstractions;
using SullyTech.Wpf.Controls.Window.Dialog.Services.DialogWindow.Interfaces;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Dialogs.Message.Window.Result;
using SullyTech.Wpf.Dialogs.Message.Window.Result.Enums;

namespace SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Commands.Presenter.Yes;

public sealed class YesCommand : AsyncCommand<IMessageDialogPresenterViewModel>
{
    private readonly IDialogWindowService _dialogWindowService;

    public YesCommand(IMessageDialogPresenterViewModel callerViewModel, IDialogWindowService dialogWindowService) : base(callerViewModel)
    {
        _dialogWindowService = dialogWindowService;
    }

    public override async Task ExecuteAsync()
    {
        MessageDialogResult dialogResult = new() { ResultType = ResultType.Yes };

        await _dialogWindowService.SetDialogResultAsync(CallerViewModel.WindowId, dialogResult);
    }
}