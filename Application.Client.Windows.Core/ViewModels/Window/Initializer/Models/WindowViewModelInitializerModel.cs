using Application.Client.Windows.Core.ViewModels.Window.Initializer.Models.Interfaces;
using Application.Client.Windows.Core.ViewModels.WindowSettings.Initializer.Models.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Core.ViewModels.Window.Initializer.Models;

public class WindowViewModelInitializerModel<TWindowSettingsViewModelInitializerModel> : IWindowViewModelInitializerModel 
    where TWindowSettingsViewModelInitializerModel : IWindowSettingsViewModelInitializerModel
{
    private readonly TWindowSettingsViewModelInitializerModel? _windowSettings;
    public TWindowSettingsViewModelInitializerModel WindowSettings
    {
        get
        {
            Guard.ThrowIfNull(_windowSettings, nameof(WindowSettings));
            
            return _windowSettings!;
        }

        init
        {
            Guard.ThrowIfNull(value, nameof(WindowSettings));

            _windowSettings = value;
        }
    }
}