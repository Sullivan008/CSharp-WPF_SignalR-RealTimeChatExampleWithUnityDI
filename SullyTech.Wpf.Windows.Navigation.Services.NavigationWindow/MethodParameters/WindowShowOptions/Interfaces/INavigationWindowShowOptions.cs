using SullyTech.Wpf.Windows.Navigation.ViewModels.Initializers.NavigationWindow.Models.Interfaces;
using SullyTech.Wpf.Windows.Navigation.ViewModels.Initializers.NavigationWindowSettings.Models.Interfaces;

namespace SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow.MethodParameters.WindowShowOptions.Interfaces;

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