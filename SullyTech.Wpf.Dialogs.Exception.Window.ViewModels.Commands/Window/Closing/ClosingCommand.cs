using SullyTech.Wpf.Controls.Window.Core.ViewModels.Commands.Abstractions;
using SullyTech.Wpf.Dialogs.Exception.Window.Interfaces;
using SullyTech.Wpf.Dialogs.Exception.Window.Result;
using SullyTech.Wpf.Dialogs.Exception.Window.Result.Enums;
using SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Services.Window.Destroyer.Interfaces;

namespace SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Commands.Window.Closing;

public sealed class ClosingCommand : AsyncCommand<IExceptionDialogWindowViewModel, IExceptionDialogWindow>
{
    private readonly IWindowDestroyerService _windowDestroyerService;

    public ClosingCommand(IExceptionDialogWindowViewModel callerViewModel, IWindowDestroyerService windowDestroyerService) : base(callerViewModel)
    {
        _windowDestroyerService = windowDestroyerService;
    }

    public override async Task ExecuteAsync(IExceptionDialogWindow window)
    {
        if (window.DialogResult.HasValue == false)
        {
            CallerViewModel.DialogResult = new ExceptionDialogResult { ResultType = ResultType.None };
            window.DialogResult = false;
        }

        await _windowDestroyerService.DestroyWindowAsync(window);
    }
}