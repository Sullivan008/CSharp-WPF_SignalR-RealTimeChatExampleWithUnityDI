using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using SullyTech.Wpf.Controls.Window.Core.Presenter.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Controls.Window.Core.ViewModels.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Controls.Window.Core.ViewModels.Window;

public class WindowViewModel<TIWindowSettingsViewModel> : IWindowViewModel, INotifyPropertyChanged
    where TIWindowSettingsViewModel : IWindowSettingsViewModel
{
    public WindowViewModel(TIWindowSettingsViewModel settings)
    {
        Settings = settings;
    }

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

    private IPresenter? _presenter;
    public IPresenter Presenter
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

    IWindowSettingsViewModel IWindowViewModel.Settings => Settings;

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
