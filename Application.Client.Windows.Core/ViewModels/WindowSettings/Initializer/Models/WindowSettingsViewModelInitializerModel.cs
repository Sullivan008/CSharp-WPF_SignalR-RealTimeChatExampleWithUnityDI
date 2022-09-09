using Application.Client.Windows.Core.ViewModels.WindowSettings.Initializer.Models.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Core.ViewModels.WindowSettings.Initializer.Models;

public class WindowSettingsViewModelInitializerModel : IWindowSettingsViewModelInitializerModel
{
    public string Title { get; init; } = string.Empty;

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