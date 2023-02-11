using System.ComponentModel;
using System.Runtime.CompilerServices;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.PresenterData;

public class PresenterDataViewModel : IPresenterDataViewModel, INotifyPropertyChanged
{
    public virtual async Task OnInit()
    {
        await Task.CompletedTask;
    }

    public virtual async Task OnDestroy()
    {
        await Task.CompletedTask;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}