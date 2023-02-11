using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Windows.Core.Window.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Windows.Core.Window.ViewModels.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Windows.Core.Window.ViewModels.Window;

public class WindowViewModel<TIWindowSettingsViewModel> : IWindowViewModel, INotifyPropertyChanged
    where TIWindowSettingsViewModel : IWindowSettingsViewModel
{
    public WindowViewModel(TIWindowSettingsViewModel settings)
    {
        Settings = settings;
    }

    private string? _presenterWindowId;
    public string PresenterWindowId
    {
        get
        {
            Guard.Guard.ThrowIfNullOrWhitespace(_presenterWindowId, nameof(PresenterWindowId));

            return _presenterWindowId!;
        }

        set
        {
            Guard.Guard.ThrowIfNotNullOrNotWhitespace(_presenterWindowId, nameof(PresenterWindowId));
            Guard.Guard.ThrowIfNullOrWhitespace(value, nameof(value));

            _presenterWindowId = value;
        }
    }

    private TIWindowSettingsViewModel? _settings;
    public TIWindowSettingsViewModel Settings
    {
        get
        {
            Guard.Guard.ThrowIfNull(_settings, nameof(Settings));

            return _settings!;
        } 

        set
        {
            _settings = value;
            OnPropertyChanged();
        }
    }

    private IPresenterViewModel? _presenter;
    public IPresenterViewModel Presenter
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

    private ICommand? _closeWindowCommand;
    public ICommand CloseWindowCommand
    {
        get
        {
            Guard.Guard.ThrowIfNull(_closeWindowCommand, nameof(CloseWindowCommand));

            return _closeWindowCommand!;
        }

        set => _closeWindowCommand = value;
    }

    IWindowSettingsViewModel IWindowViewModel.Settings => Settings;

    public virtual async Task OnInitAsync()
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
