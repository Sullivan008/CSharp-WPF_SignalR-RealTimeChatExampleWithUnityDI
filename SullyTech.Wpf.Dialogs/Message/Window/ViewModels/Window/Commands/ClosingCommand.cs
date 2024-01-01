using SullyTech.Wpf.Controls.Window.Core.Commands.Abstractions;
using SullyTech.Wpf.Dialogs.Message.Window.Results;
using SullyTech.Wpf.Dialogs.Message.Window.Results.Enums;
using SullyTech.Wpf.Dialogs.Message.Window.UserControls;
using SullyTech.Wpf.Services.Window.Destroyer.Interfaces;

namespace SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Window.Commands;

internal sealed class ClosingCommand : AsyncCommand<MessageDialogWindowViewModel, MessageDialogWindow>
{
    private readonly IWindowDestroyerService _windowDestroyerService;

    public ClosingCommand(MessageDialogWindowViewModel callerViewModel, IWindowDestroyerService windowDestroyerService) : base(callerViewModel)
    {
        _windowDestroyerService = windowDestroyerService;
    }

    public override async Task ExecuteAsync(MessageDialogWindow window)
    {
        if (window.DialogResult is null)
        {
            window.Result = new MessageDialogResult { ResultType = ResultType.None };
            window.DialogResult = false;
        }

        await _windowDestroyerService.DestroyWindowAsync(window);
    }
}