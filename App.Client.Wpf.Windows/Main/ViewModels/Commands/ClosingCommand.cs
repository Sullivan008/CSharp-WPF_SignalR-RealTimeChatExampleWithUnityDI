using App.Client.Wpf.Windows.Main.UserControls;
using SullyTech.Wpf.Controls.Window.Core.Commands.Abstractions;
using SullyTech.Wpf.Services.Window.Destroyer.Interfaces;

namespace App.Client.Wpf.Windows.Main.ViewModels.Commands;

internal sealed class ClosingCommand : AsyncCommand<MainWindowViewModel, MainWindow>
{
    private readonly IWindowDestroyerService _windowDestroyerService;

    public ClosingCommand(MainWindowViewModel callerViewModel, IWindowDestroyerService windowDestroyerService) : base(callerViewModel)
    {
        _windowDestroyerService = windowDestroyerService;
    }

    public override async Task ExecuteAsync(MainWindow window)
    {
        await _windowDestroyerService.DestroyWindowAsync(window);
    }
}