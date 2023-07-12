using System.ComponentModel;
using System.Runtime.CompilerServices;
using SullyTech.Wpf.Controls.Window.Core.ViewModels.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Controls.Window.Core.ViewModels.WindowSettings;

public class WindowSettingsViewModel : IWindowSettingsViewModel, INotifyPropertyChanged
{
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