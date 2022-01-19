using Application.Client.Windows.Windows.ApplicationWindow.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Windows.ApplicationWindow.ViewModels.Initializers.Abstractions;

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