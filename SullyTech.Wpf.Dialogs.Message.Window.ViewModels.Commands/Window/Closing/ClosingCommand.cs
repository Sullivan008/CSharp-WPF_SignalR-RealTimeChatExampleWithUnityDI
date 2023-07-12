using SullyTech.Wpf.Controls.Window.Core.ViewModels.Commands.Abstractions;
using SullyTech.Wpf.Dialogs.Message.Window.Interfaces;
using SullyTech.Wpf.Dialogs.Message.Window.Result;
using SullyTech.Wpf.Dialogs.Message.Window.Result.Enums;
using SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Services.Window.Destroyer.Interfaces;

namespace SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Commands.Window.Closing;

public sealed class ClosingCommand : AsyncCommand<IMessageDialogWindowViewModel, IMessageDialogWindow>
{
    private readonly IWindowDestroyerService _windowDestroyerService;

    public ClosingCommand(IMessageDialogWindowViewModel callerViewModel, IWindowDestroyerService windowDestroyerService) : base(callerViewModel)
    {
        _windowDestroyerService = windowDestroyerService;
    }

    public override async Task ExecuteAsync(IMessageDialogWindow window)
    {
        if (window.DialogResult.HasValue == false)
        {
            CallerViewModel.DialogResult = new MessageDialogResult { ResultType = ResultType.None };
            window.DialogResult = false;
        }

        await _windowDestroyerService.DestroyWindowAsync(window);
    }
}