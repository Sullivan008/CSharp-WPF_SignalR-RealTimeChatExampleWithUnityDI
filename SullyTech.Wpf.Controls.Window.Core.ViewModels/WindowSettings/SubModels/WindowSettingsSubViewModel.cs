using System.ComponentModel;
using System.Runtime.CompilerServices;
using SullyTech.Wpf.Controls.Window.Core.ViewModels.Interfaces.WindowSettings.SubInterfaces;

namespace SullyTech.Wpf.Controls.Window.Core.ViewModels.WindowSettings.SubModels;

public class WindowSettingsSubViewModel : IWindowSettingsSubViewModel, INotifyPropertyChanged
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