using Application.Client.Windows.Core.Commands.Abstractions;
using Application.Client.Windows.NavigationWindow.Core.Window.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindow.Commands;

internal class CloseWindowCommand : AsyncWindowCommand<MainWindowViewModel, INavigationWindow>
{
    public CloseWindowCommand(MainWindowViewModel callerViewModel) : base(callerViewModel)
    { }

    public override async Task ExecuteAsync(INavigationWindow parameter)
    {
        await Task.CompletedTask;
    }
}