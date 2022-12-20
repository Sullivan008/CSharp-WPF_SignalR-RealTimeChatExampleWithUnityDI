using SullyTech.Wpf.Windows.Navigation.ViewModels.Initializers.NavigationWindowSettings.Models.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindowSettings.Initializer.Models;

internal interface IMainWindowSettingsViewModelInitializerModel : INavigationWindowSettingsViewModelInitializerModel
{
    public string Title { get; init; }

    public double Width { get; init; }

    public double Height { get; init; }
}