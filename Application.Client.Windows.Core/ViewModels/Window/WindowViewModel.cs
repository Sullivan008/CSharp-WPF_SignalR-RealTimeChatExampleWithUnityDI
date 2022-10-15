using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using App.Core.Guard.Implementation;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Interfaces;
using Application.Client.Windows.Core.ViewModels.Window.Interfaces;
using Application.Client.Windows.Core.ViewModels.WindowSettings.Interfaces;

namespace Application.Client.Windows.Core.ViewModels.Window;

public class WindowViewModel<TWindowSettingsViewModel> : INotifyPropertyChanged, IWindowViewModel 
    where TWindowSettingsViewModel : IWindowSettingsViewModel, new()
{
    private TWindowSettingsViewModel _windowSettings = new();
    public TWindowSettingsViewModel WindowSettings
    {
        get => _windowSettings;
        set
        {
            Guard.ThrowIfNull(value, nameof(WindowSettings));
            _windowSettings = value;

            OnPropertyChanged();
        }
    }
    
    private IContentPresenterViewModel? _contentPresenter;
    public IContentPresenterViewModel ContentPresenter
    {
        get
        {
            Guard.ThrowIfNull(_contentPresenter, nameof(ContentPresenter));

            return _contentPresenter!;
        }

        set
        {
            Guard.ThrowIfNull(value, nameof(ContentPresenter));
            _contentPresenter = value;

            OnPropertyChanged();
        }
    }

    IWindowSettingsViewModel IWindowViewModel.WindowSettings
    {
        get => WindowSettings;
    }

    private ICommand? _closeWindowCommand;
    public ICommand CloseWindowCommand
    {
        get
        {
            Guard.ThrowIfNull(_closeWindowCommand, nameof(CloseWindowCommand));

            return _closeWindowCommand!;
        }

        set
        {
            Guard.ThrowIfNull(value, nameof(CloseWindowCommand));

            _closeWindowCommand = value;
        }
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