using App.Client.Wpf.Windows.Main.ViewModels.Commands;
using SullyTech.Wpf.Controls.Window.Standard.Core.ViewModels.Window;
using SullyTech.Wpf.Services.Window.Destroyer.Interfaces;

namespace App.Client.Wpf.Windows.Main.ViewModels;

public sealed class MainWindowViewModel : StandardWindowViewModel
{
    public MainWindowViewModel(IWindowDestroyerService windowDestroyerService)
    {
        LoadedCommand = new LoadedCommand(this);
        ClosingCommand = new ClosingCommand(this, windowDestroyerService);
    }
}
