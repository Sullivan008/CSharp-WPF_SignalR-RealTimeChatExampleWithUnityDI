using SullyTech.Wpf.Windows.Core.Commands.Abstractions;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindow.Commands;

internal class CloseCommand : AsyncCommand<MainWindowViewModel, IMainWindow>
{
    public CloseCommand(MainWindowViewModel callerViewModel) : base(callerViewModel)
    { }

    public override async Task ExecuteAsync(IMainWindow parameter)
    {
        await Task.CompletedTask;
    }
}