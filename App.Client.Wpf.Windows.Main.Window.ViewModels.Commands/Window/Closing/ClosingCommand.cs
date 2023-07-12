using App.Client.Wpf.Windows.Main.Window.Interfaces;
using App.Client.Wpf.Windows.Main.Window.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Controls.Window.Core.ViewModels.Commands.Abstractions;
using SullyTech.Wpf.Services.Window.Destroyer.Interfaces;

namespace App.Client.Wpf.Windows.Main.Window.ViewModels.Commands.Window.Closing;

public sealed class ClosingCommand : AsyncCommand<IMainWindowViewModel, IMainWindow>
{
    private readonly IWindowDestroyerService _windowDestroyerService;

    public ClosingCommand(IMainWindowViewModel callerViewModel, IWindowDestroyerService windowDestroyerService) : base(callerViewModel)
    {
        _windowDestroyerService = windowDestroyerService;
    }

    public override async Task ExecuteAsync(IMainWindow window)
    {
        await _windowDestroyerService.DestroyWindowAsync(window);
    }
}