using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindowSettings.Interfaces;

namespace Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Interfaces;

public interface IApplicationWindowViewModel
{
    public IApplicationWindowSettingsViewModel WindowSettings { get; }
}