using SullyTech.App.Client.Wpf.Windows.Main.Window.Interfaces;
using SullyTech.App.Client.Wpf.Windows.Main.Window.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Windows.Core.Window.ViewModels.Commands.Abstractions;

namespace SullyTech.App.Client.Wpf.Windows.Main.Window.ViewModels.Commands.Window;

public sealed class CloseCommand : AsyncCommand<IMainWindowViewModel, IMainWindow>
{
    public CloseCommand(IMainWindowViewModel callerViewModel) : base(callerViewModel)
    { }

    public override async Task ExecuteAsync(IMainWindow parameter)
    {
        await Task.CompletedTask;
    }
}