using SullyTech.Wpf.Controls.Window.Core.Commands.Abstractions;
using SullyTech.Wpf.Dialogs.Exception.Window.Results;
using SullyTech.Wpf.Dialogs.Exception.Window.Results.Enums;
using SullyTech.Wpf.Dialogs.Exception.Window.UserControls;
using SullyTech.Wpf.Services.Window.Destroyer.Interfaces;

namespace SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Window.Commands;

internal sealed class ClosingCommand : AsyncCommand<ExceptionDialogWindowViewModel, ExceptionDialogWindow>
{
    private readonly IWindowDestroyerService _windowDestroyerService;

    public ClosingCommand(ExceptionDialogWindowViewModel callerViewModel, IWindowDestroyerService windowDestroyerService) : base(callerViewModel)
    {
        _windowDestroyerService = windowDestroyerService;
    }

    public override async Task ExecuteAsync(ExceptionDialogWindow window)
    {
        if (window.Result is null)
        {
            window.Result = new ExceptionDialogResult { ResultType = ResultType.None };
            window.DialogResult = false;
        }

        await _windowDestroyerService.DestroyWindowAsync(window);
    }
}