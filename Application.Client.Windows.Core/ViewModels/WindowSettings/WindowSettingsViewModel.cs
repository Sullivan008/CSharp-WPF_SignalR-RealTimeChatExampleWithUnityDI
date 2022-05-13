using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Application.Client.Windows.Core.ViewModels.WindowSettings.Interfaces;

namespace Application.Client.Windows.Core.ViewModels.WindowSettings;

public class WindowSettingsViewModel : INotifyPropertyChanged, IWindowSettingsViewModel
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

            CenterLocation();
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

            CenterLocation();
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

    int IWindowSettingsViewModel.Height
    {
        set => Height = value;
    }

    int IWindowSettingsViewModel.Width
    {
        set => Width = value;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        if (name != null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    private void CenterLocation()
    {
        Top = (SystemParameters.WorkArea.Height - Height) / 2;
        Left = (SystemParameters.WorkArea.Width - Width) / 2;
    }
}