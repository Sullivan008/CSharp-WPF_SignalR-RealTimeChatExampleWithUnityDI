using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SullyTech.Wpf.Controls.Presenter.Core.ViewModels.Presenter;

public class PresenterViewModel : INotifyPropertyChanged
{
    private string? _windowId;
    public string WindowId
    {
        get
        {
            Guard.Guard.ThrowIfNullOrWhitespace(_windowId);

            return _windowId!;
        }

        set
        {
            Guard.Guard.ThrowIfNullOrWhitespace(value);
            Guard.Guard.ThrowIfNotNullOrNotWhitespace(_windowId);

            _windowId = value;
        }
    }

    private ICommand? _loadedCommand;
    public ICommand LoadedCommand
    {
        get
        {
            Guard.Guard.ThrowIfNull(_loadedCommand);

            return _loadedCommand!;
        }

        set => _loadedCommand = value;
    }

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
    public virtual void OnPropertyChanged([CallerMemberName] string? name = default)
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}