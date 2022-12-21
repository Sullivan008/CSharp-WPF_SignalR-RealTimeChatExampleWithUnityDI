using SullyTech.App.Client.Wpf.Windows.Main.Interfaces.Window;
using SullyTech.App.Client.Wpf.Windows.Main.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Windows.Core.ViewModels.Commands.Abstractions;

namespace SullyTech.App.Client.Wpf.Windows.Main.ViewModels.Commands.Window;

public sealed class CloseCommand : AsyncCommand<IMainWindowViewModel, IMainWindow>
{
    public CloseCommand(IMainWindowViewModel callerViewModel) : base(callerViewModel)
    { }

    public override async Task ExecuteAsync(IMainWindow parameter)
    {
        await Task.CompletedTask;
    }
}