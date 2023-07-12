using System.ComponentModel;
using System.Runtime.CompilerServices;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.PresenterData;

public class PresenterDataViewModel : IPresenterDataViewModel, INotifyPropertyChanged
{
    public virtual async Task OnBeforeLoadAsync()
    {
        await Task.CompletedTask;
    }

    public virtual async Task OnAfterLoadAsync()
    {
        await Task.CompletedTask;
    }

    public virtual async Task OnDestroyAsync()
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