using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SullyTech.Wpf.Controls.Presenter.Core.ViewModels.Presenter.SubModels;

public class PresenterSubViewModel : INotifyPropertyChanged
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