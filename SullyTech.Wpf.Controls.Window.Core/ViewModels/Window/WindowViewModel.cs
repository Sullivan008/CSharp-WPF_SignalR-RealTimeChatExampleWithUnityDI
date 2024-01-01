using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SullyTech.Wpf.Controls.Window.Core.ViewModels.Window;

public class WindowViewModel : INotifyPropertyChanged
{
    private string? _id;
    public string Id
    {
        get
        {
            Guard.Guard.ThrowIfNullOrWhitespace(_id, nameof(Id));

            return _id!;
        }

        set
        {
            Guard.Guard.ThrowIfNotNullOrNotWhitespace(_id, nameof(Id));
            Guard.Guard.ThrowIfNullOrWhitespace(value, nameof(value));

            _id = value;
        }
    }

    private string _title = string.Empty;
    public string Title
    {
        get => _title;
        set
        {
            _title = value;
            OnPropertyChanged();
        }
    }

    private double _height;
    public double Height
    {
        get => _height;
        set
        {
            _height = value;
            OnPropertyChanged();
        }
    }

    private double _width;
    public double Width
    {
        get => _width;
        set
        {
            _width = value;
            OnPropertyChanged();
        }
    }

    private double _top;
    public double Top
    {
        get => _top;
        set
        {
            _top = value;
            OnPropertyChanged();
        }
    }

    private double _bottom;
    public double Bottom
    {
        get => _bottom;
        set
        {
            _bottom = value;
            OnPropertyChanged();
        }
    }

    private double _left;
    public double Left
    {
        get => _left;
        set
        {
            _left = value;
            OnPropertyChanged();
        }
    }

    private double _right;
    public double Right
    {
        get => _right;
        set
        {
            _right = value;
            OnPropertyChanged();
        }
    }

    private Presenter.Core.UserControls.Presenter.Presenter? _presenter;
    public Presenter.Core.UserControls.Presenter.Presenter Presenter
    {
        get
        {
            Guard.Guard.ThrowIfNull(_presenter, nameof(Presenter));
            return _presenter!;
        }

        set
        {
            _presenter = value;
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

    private ICommand? _closeWindowCommand;
    public ICommand ClosingCommand
    {
        get
        {
            Guard.Guard.ThrowIfNull(_closeWindowCommand, nameof(ClosingCommand));

            return _closeWindowCommand!;
        }

        set => _closeWindowCommand = value;
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
