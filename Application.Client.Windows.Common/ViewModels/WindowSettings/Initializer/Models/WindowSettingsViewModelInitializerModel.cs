using Application.Client.Windows.Core.ViewModels.WindowSettings.Initializer.Models.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Core.ViewModels.WindowSettings.Initializer.Models;

public class WindowSettingsViewModelInitializerModel : IWindowSettingsViewModelInitializerModel
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