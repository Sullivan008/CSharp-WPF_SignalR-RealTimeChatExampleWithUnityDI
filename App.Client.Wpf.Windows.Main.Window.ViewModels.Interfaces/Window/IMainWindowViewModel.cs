using System.Windows.Input;
using App.Client.Wpf.Windows.Main.Window.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Interfaces.Window;

namespace App.Client.Wpf.Windows.Main.Window.ViewModels.Interfaces.Window;

public interface IMainWindowViewModel : IStandardWindowViewModel
{
    public new IMainWindowSettingsViewModel Settings { get; }

    public ICommand OnConnectionLostCommand { get; }
}