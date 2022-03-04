using System.ComponentModel;
using System.Runtime.CompilerServices;
using Application.Client.Windows.Core.ViewModels.WindowSettings.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Core.ViewModels.WindowSettings;

public class WindowSettingsViewModel : INotifyPropertyChanged, IWindowSettingsViewModel
{
    private string _title = string.Empty;
    public string Title
    {
        get
        {
            Guard.ThrowIfNullOrWhitespace(_title, nameof(Title));

            return _title;
        }

        set
        {
            Guard.ThrowIfNullOrWhitespace(value, nameof(Title));
            _title = value;

            OnPropertyChanged();
        }
    }

    private int? _height;
    public int Height
    {
        get
        {
            Guard.ThrowIfNull(_height, nameof(Height));

            return _height!.Value;
        }

        set
        {
            _height = value;

            OnPropertyChanged();
        }
    }

    int IWindowSettingsViewModel.Height
    {
        set => Height = value;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        if (name != null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}