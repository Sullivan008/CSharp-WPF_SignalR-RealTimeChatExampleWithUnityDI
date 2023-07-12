using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Presenter;

public class PresenterViewModel<TPresenterDataViewModel> : IPresenterViewModel, INotifyPropertyChanged
    where TPresenterDataViewModel : IPresenterDataViewModel
{
    protected PresenterViewModel(TPresenterDataViewModel data)
    {
        Data = data;
    }

    IPresenterDataViewModel IPresenterViewModel.Data => Data;

    private string? _windowId;
    public string WindowId
    {
        get
        {
            Guard.Guard.ThrowIfNullOrWhitespace(_windowId, nameof(WindowId));

            return _windowId!;
        }

        set
        {
            Guard.Guard.ThrowIfNotNullOrNotWhitespace(_windowId, nameof(WindowId));
            Guard.Guard.ThrowIfNullOrWhitespace(value, nameof(value));

            _windowId = value;
        }
    }

    private TPresenterDataViewModel? _data;
    public TPresenterDataViewModel Data
    {
        get
        {
            Guard.Guard.ThrowIfNull(_data, nameof(Data));

            return _data!;
        }

        set
        {
            _data = value;
            OnPropertyChanged();
        }
    }

    private ICommand? _loadedCommand;
    public ICommand LoadedCommand
    {
        get
        {
            Guard.Guard.ThrowIfNull(_loadedCommand, nameof(LoadedCommand));

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
    public virtual void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}