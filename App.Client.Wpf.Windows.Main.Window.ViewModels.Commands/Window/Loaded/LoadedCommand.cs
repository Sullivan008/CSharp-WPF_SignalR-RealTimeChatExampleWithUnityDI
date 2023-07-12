using App.Client.Wpf.Windows.Main.Window.Interfaces;
using App.Client.Wpf.Windows.Main.Window.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Controls.Window.Core.ViewModels.Commands.Abstractions;

namespace App.Client.Wpf.Windows.Main.Window.ViewModels.Commands.Window.Loaded;

public sealed class LoadedCommand : AsyncCommand<IMainWindowViewModel, IMainWindow>
{
    public LoadedCommand(IMainWindowViewModel callerViewModel) : base(callerViewModel)
    { }

    public override async Task ExecuteAsync(IMainWindow window)
    {
        await ((IMainWindowViewModel)window.DataContext).Settings.OnAfterLoadAsync();
        await ((IMainWindowViewModel)window.DataContext).OnAfterLoadAsync();
    }
}