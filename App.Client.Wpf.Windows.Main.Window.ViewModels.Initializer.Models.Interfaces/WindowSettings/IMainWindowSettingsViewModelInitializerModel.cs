using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Initializer.Models.Interfaces.WindowSettings;

namespace App.Client.Wpf.Windows.Main.Window.ViewModels.Initializer.Models.Interfaces.WindowSettings;

public interface IMainWindowSettingsViewModelInitializerModel : IStandardWindowSettingsViewModelInitializerModel
{
    public double Width { get; init; }

    public double Height { get; init; }
}