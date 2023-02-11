using SullyTech.Wpf.Windows.Navigation.Window.ViewModels.Initializers.NavigationWindowSettings.Models.Interfaces;

namespace SullyTech.App.Client.Wpf.Windows.Main.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;

public interface IMainWindowSettingsViewModelInitializerModel : INavigationWindowSettingsViewModelInitializerModel
{
    public string Title { get; init; }

    public double Width { get; init; }

    public double Height { get; init; }
}