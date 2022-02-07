using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Interfaces;
using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindowSettings.Interfaces;
using Application.Client.Windows.Core.ViewModels.Window;

namespace Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow;

public class ApplicationWindowViewModel<TApplicationWindowSettingsViewModel> : WindowViewModel<TApplicationWindowSettingsViewModel>, IApplicationWindowViewModel
    where TApplicationWindowSettingsViewModel : IApplicationWindowSettingsViewModel, new()
{ }