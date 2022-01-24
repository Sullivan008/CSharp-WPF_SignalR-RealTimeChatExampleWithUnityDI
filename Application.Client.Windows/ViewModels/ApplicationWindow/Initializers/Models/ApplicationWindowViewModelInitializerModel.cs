using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindowSettings.Initializers.Models.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Initializers.Models;

public class ApplicationWindowViewModelInitializerModel<TApplicationWindowSettingsViewModelInitializerModel>
    where TApplicationWindowSettingsViewModelInitializerModel : IApplicationWindowSettingsViewModelInitializerModel
{
    private readonly TApplicationWindowSettingsViewModelInitializerModel? _windowSettings;
    public TApplicationWindowSettingsViewModelInitializerModel WindowSettings
    {
        get
        {
            Guard.ThrowIfNull(_windowSettings, nameof(WindowSettings));

            return _windowSettings!;
        }

        init => _windowSettings = value;
    }
}