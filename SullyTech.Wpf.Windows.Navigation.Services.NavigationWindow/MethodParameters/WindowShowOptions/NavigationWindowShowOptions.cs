using SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow.MethodParameters.WindowShowOptions.Interfaces;
using SullyTech.Wpf.Windows.Navigation.ViewModels.Initializers.NavigationWindow.Models.Interfaces;
using SullyTech.Wpf.Windows.Navigation.ViewModels.Initializers.NavigationWindowSettings.Models.Interfaces;
using SullyTech.Wpf.Windows.Navigation.ViewModels.Interfaces.NavigationWindow;
using SullyTech.Wpf.Windows.Navigation.Window.Interfaces;

namespace SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow.MethodParameters.WindowShowOptions;

public sealed class NavigationWindowShowOptions<TNavigationWindow, TNavigationWindowViewModel> : INavigationWindowShowOptions
    where TNavigationWindow : INavigationWindow
    where TNavigationWindowViewModel : INavigationWindowViewModel
{
    Type INavigationWindowShowOptions.WindowType => typeof(TNavigationWindow);

    Type INavigationWindowShowOptions.WindowViewModelType => typeof(TNavigationWindowViewModel);

    INavigationWindowViewModelInitializerModel? INavigationWindowShowOptions.WindowViewModelInitializerModel => WindowViewModelInitializerModel;

    INavigationWindowSettingsViewModelInitializerModel? INavigationWindowShowOptions.WindowSettingsViewModelInitializerModel => WindowSettingsViewModelInitializerModel;

    public INavigationWindowViewModelInitializerModel? WindowViewModelInitializerModel { get; init; }

    public INavigationWindowSettingsViewModelInitializerModel? WindowSettingsViewModelInitializerModel { get; init; }
}