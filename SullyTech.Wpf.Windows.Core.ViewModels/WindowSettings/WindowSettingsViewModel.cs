using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using SullyTech.Wpf.Windows.Core.ViewModels.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Windows.Core.ViewModels.WindowSettings;

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

            CalculateCenterLocation();
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

            CalculateCenterLocation();
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

    private void CalculateCenterLocation()
    {
        Top = (SystemParameters.WorkArea.Height - Height) / 2;
        Left = (SystemParameters.WorkArea.Width - Width) / 2;
    }
}