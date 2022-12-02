using SullyTech.Wpf.Windows.Core.Commands.Abstractions;
using SullyTech.Wpf.Windows.Navigation.Window.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindow.Commands;

internal class CloseCommand : AsyncCommand<MainWindowViewModel, INavigationWindow>
{
    public CloseCommand(MainWindowViewModel callerViewModel) : base(callerViewModel)
    { }

    public override async Task ExecuteAsync(INavigationWindow parameter)
    {
        await Task.CompletedTask;
    }
}