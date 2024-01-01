using App.Client.Wpf.Windows.Main.UserControls;
using SullyTech.Wpf.Controls.Window.Core.Commands.Abstractions;

namespace App.Client.Wpf.Windows.Main.ViewModels.Commands;

internal sealed class LoadedCommand : AsyncCommand<MainWindowViewModel, MainWindow>
{
    public LoadedCommand(MainWindowViewModel callerViewModel) : base(callerViewModel)
    { }

    public override async Task ExecuteAsync(MainWindow window)
    {
        await ((MainWindowViewModel)window.DataContext).OnAfterLoadAsync();
    }
}