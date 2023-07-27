using App.Client.Wpf.Windows.Main.Window.ViewModels.Initializer.Models.Interfaces.WindowSettings;
using SullyTech.Guard;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Initializer.Models.WindowSettings;

namespace App.Client.Wpf.Windows.Main.Window.ViewModels.Initializer.Models.WindowSettings;

public sealed class MainWindowSettingsViewModelInitializerModel : StandardWindowSettingsViewModelInitializerModel, IMainWindowSettingsViewModelInitializerModel
{
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