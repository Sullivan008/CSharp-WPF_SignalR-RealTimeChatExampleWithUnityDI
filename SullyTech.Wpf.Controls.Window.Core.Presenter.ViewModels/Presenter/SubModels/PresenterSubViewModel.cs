using System.ComponentModel;
using System.Runtime.CompilerServices;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.Presenter.SubInterfaces;

namespace SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Presenter.SubModels;

public class PresenterSubViewModel : IPresenterSubViewModel, INotifyPropertyChanged
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