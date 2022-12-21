using SullyTech.Wpf.Windows.Navigation.ViewModels.Initializers.NavigationWindowSettings.Models.Interfaces;

namespace SullyTech.App.Client.Wpf.Windows.Main.ViewModels.Initializers.WindowSettings.Models.Interfaces;

internal interface IMainWindowSettingsViewModelInitializerModel : INavigationWindowSettingsViewModelInitializerModel
{
    public string Title { get; init; }

    public double Width { get; init; }

    public double Height { get; init; }
}