using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Windows.ApplicationWindow.ViewModels.Initializers.Abstractions;

public abstract class BaseApplicationWindowViewModelInitializerModel
{
    private readonly BaseApplicationWindowSettingsViewModelInitializerModel? _windowSettings;
    public BaseApplicationWindowSettingsViewModelInitializerModel WindowSettings
    {
        get
        {
            Guard.ThrowIfNull(_windowSettings, nameof(WindowSettings));

            return _windowSettings!;
        }

        init => _windowSettings = value;
    }
}