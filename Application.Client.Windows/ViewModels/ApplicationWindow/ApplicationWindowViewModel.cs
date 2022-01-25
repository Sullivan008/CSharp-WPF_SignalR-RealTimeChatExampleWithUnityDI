using Application.Client.Common.ViewModels;
using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Interfaces;
using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindowSettings.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow;

public class ApplicationWindowViewModel<TApplicationWindowSettingsViewModel> : ViewModelBase, IApplicationWindowViewModel
    where TApplicationWindowSettingsViewModel : IApplicationWindowSettingsViewModel, new()
{
    private TApplicationWindowSettingsViewModel _windowSettings = new();
    public TApplicationWindowSettingsViewModel WindowSettings
    {
        get => _windowSettings;
        set
        {
            Guard.ThrowIfNull(value, nameof(WindowSettings));
            _windowSettings = value;

            OnPropertyChanged();
        }
    }

    IApplicationWindowSettingsViewModel IApplicationWindowViewModel.WindowSettings => WindowSettings;
}