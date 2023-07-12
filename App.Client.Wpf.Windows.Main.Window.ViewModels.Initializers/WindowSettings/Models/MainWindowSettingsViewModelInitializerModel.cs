using App.Client.Wpf.Windows.Main.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;
using SullyTech.Guard;

namespace App.Client.Wpf.Windows.Main.Window.ViewModels.Initializers.WindowSettings.Models;

public sealed class MainWindowSettingsViewModelInitializerModel : IMainWindowSettingsViewModelInitializerModel
{
    private readonly string? _title;
    public string Title
    {
        get
        {
            Guard.ThrowIfNullOrWhitespace(_title, nameof(Title));

            return _title!;
        }

        init => _title = value;
    }

    private readonly double? _width;
    public double Width
    {
        get
        {
            Guard.ThrowIfNull(_width, nameof(Width));

            return _width!.Value;
        }

        init => _width = value;
    }

    private readonly double? _height;
    public double Height
    {
        get
        {
            Guard.ThrowIfNull(_height, nameof(Height));

            return _height!.Value;
        }

        init => _height = value;
    }
}