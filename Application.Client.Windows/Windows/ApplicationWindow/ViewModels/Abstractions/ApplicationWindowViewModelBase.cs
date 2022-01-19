using Application.Client.Common.ViewModels;
using Application.Client.Windows.Windows.ApplicationWindow.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Windows.ApplicationWindow.ViewModels.Abstractions;

public abstract class ApplicationWindowViewModelBase<TApplicationWindowSettingsViewModel> : ViewModelBase, IApplicationWindowViewModel
    where TApplicationWindowSettingsViewModel : IApplicationWindowSettingsViewModel, new()
{
    private TApplicationWindowSettingsViewModel? _windowSettings = new();
    public TApplicationWindowSettingsViewModel WindowSettings
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