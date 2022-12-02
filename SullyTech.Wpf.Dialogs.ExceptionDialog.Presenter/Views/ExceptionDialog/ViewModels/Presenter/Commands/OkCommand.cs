using SullyTech.Wpf.Dialogs.ExceptionDialog.Result;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Result.Enums;
using SullyTech.Wpf.Windows.Core.Presenter.Commands.Abstractions;
using SullyTech.Wpf.Windows.Dialog.Services.CurrentDialogWindow.Interfaces;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Presenter.Views.ExceptionDialog.ViewModels.Presenter.Commands;

internal sealed class OkCommand : AsyncCommand<ExceptionDialogViewModel>
{
    private readonly ICurrentDialogWindowService _currentWindowService;

    public OkCommand(ExceptionDialogViewModel callerViewModel, ICurrentDialogWindowService currentWindowService) : base(callerViewModel)
    {
        _currentWindowService = currentWindowService;
    }

    public override async Task ExecuteAsync()
    {
        ExceptionDialogResult dialogResult = new() { ResultType = ResultType.Ok };

        await _currentWindowService.SetDialogResultAsync(dialogResult);
        await _currentWindowService.CloseWindowAsync();
    }
}