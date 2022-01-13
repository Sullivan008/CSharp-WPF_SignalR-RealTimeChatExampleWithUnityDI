using Application.Client.Common.ViewModels;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Windows.ApplicationWindow.ViewModels.Abstractions;

public abstract class ApplicationWindowViewModelBase : ViewModelBase
{
    private ApplicationWindowSettingsViewModelBase? _windowSettings;
    public ApplicationWindowSettingsViewModelBase WindowSettings
    {
        get => _windowSettings!;
        set
        {
            Guard.ThrowIfNull(value, nameof(WindowSettings));
            _windowSettings = value;

            OnPropertyChanged();
        }
    }
}