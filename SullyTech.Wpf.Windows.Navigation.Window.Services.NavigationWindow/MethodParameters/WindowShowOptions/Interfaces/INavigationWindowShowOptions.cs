using SullyTech.Wpf.Windows.Navigation.Window.ViewModels.Initializers.NavigationWindow.Models.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Window.ViewModels.Initializers.NavigationWindowSettings.Models.Interfaces;

namespace SullyTech.Wpf.Windows.Navigation.Window.Services.NavigationWindow.MethodParameters.WindowShowOptions.Interfaces;

public interface INavigationWindowShowOptions
{
    internal Type WindowType { get; }

    internal Type WindowViewModelType { get; }

    internal Type WindowSettingsViewModelType { get; }

    internal Type? WindowViewModelInitializerModelType { get; }

    internal Type? WindowSettingsViewModelInitializerModelType { get; }

    internal INavigationWindowViewModelInitializerModel? WindowViewModelInitializerModel { get; }

    internal INavigationWindowSettingsViewModelInitializerModel? WindowSettingsViewModelInitializerModel { get; }
}