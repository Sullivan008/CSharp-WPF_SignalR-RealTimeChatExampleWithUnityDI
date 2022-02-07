using Application.Client.Windows.Core.ViewModels.WindowSettings.Interfaces;

namespace Application.Client.Windows.Core.ViewModels.Window.Interfaces;

public interface IWindowViewModel
{
    public IWindowSettingsViewModel WindowSettings { get; }
}