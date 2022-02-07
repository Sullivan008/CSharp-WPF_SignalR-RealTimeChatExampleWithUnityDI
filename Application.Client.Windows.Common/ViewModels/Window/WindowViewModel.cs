using Application.Client.Common.ViewModels;
using Application.Client.Windows.Core.ViewModels.Window.Interfaces;
using Application.Client.Windows.Core.ViewModels.WindowSettings.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Core.ViewModels.Window;

public class WindowViewModel<TWindowSettingsViewModel> : ViewModelBase, IWindowViewModel where TWindowSettingsViewModel : IWindowSettingsViewModel, new()
{
    IWindowSettingsViewModel IWindowViewModel.WindowSettings => WindowSettings;

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
}