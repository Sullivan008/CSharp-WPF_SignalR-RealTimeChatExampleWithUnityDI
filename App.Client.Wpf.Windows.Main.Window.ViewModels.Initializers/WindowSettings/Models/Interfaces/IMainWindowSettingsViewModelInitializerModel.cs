using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Initializers.WindowSettings.Models.Interfaces;

namespace App.Client.Wpf.Windows.Main.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;

public interface IMainWindowSettingsViewModelInitializerModel : IStandardWindowSettingsViewModelInitializerModel
{
    public string Title { get; init; }

    public double Width { get; init; }

    public double Height { get; init; }
}