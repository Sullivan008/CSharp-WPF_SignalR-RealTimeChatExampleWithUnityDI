using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SullyTech.Wpf.Controls.Window.Core.ViewModels.Window.SubModels;

public class WindowSubViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public virtual void OnPropertyChanged([CallerMemberName] string? name = default)
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}