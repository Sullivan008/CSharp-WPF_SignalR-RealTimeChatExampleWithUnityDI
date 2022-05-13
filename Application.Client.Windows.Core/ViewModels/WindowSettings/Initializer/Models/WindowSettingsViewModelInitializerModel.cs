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

        init
        {
            Guard.ThrowIfNullOrWhitespace(value, nameof(Title));

            _title = value;
        }
    }

    private readonly int? _height;
    public int Height
    {
        get
        {
            Guard.ThrowIfNull(_height, nameof(Height));

            return _height!.Value;
        }

        init => _height = value;
    }

    private readonly int? _width;
    public int Width
    {
        get
        {
            Guard.ThrowIfNull(_width, nameof(Width));

            return _width!.Value;
        }

        init => _width = value;
    }
}