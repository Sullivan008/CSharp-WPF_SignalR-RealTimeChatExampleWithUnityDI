using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindowSettings.Initializers.Models.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindowSettings.Initializers.Models;

public class ApplicationWindowSettingsViewModelInitializerModel : IApplicationWindowSettingsViewModelInitializerModel
{
    private readonly string _title = string.Empty;
    public string Title
    {
        get
        {
            Guard.ThrowIfNullOrWhitespace(_title, nameof(Title));

            return _title;
        }

        init => _title = value;
    }
}