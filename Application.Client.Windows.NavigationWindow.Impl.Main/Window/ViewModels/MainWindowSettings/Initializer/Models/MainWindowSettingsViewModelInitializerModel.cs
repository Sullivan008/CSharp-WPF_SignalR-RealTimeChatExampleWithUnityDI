using SullyTech.Guard;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindowSettings.Initializer.Models;

public class MainWindowSettingsViewModelInitializerModel : IMainWindowSettingsViewModelInitializerModel
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