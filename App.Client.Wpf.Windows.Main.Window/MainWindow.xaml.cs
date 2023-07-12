using App.Client.Wpf.Windows.Main.Window.Interfaces;

namespace App.Client.Wpf.Windows.Main.Window;

public sealed partial class MainWindow : SullyTech.Wpf.Controls.Window.Standard.StandardWindow, IMainWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }
}