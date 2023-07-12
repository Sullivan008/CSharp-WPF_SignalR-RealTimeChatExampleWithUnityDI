using System.ComponentModel;
using System.Runtime.CompilerServices;
using SullyTech.Wpf.Controls.Window.Core.ViewModels.Interfaces.Window.SubInterfaces;

namespace SullyTech.Wpf.Controls.Window.Core.ViewModels.Window.SubModels;

public class WindowSubViewModel : IWindowSubViewModel, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}