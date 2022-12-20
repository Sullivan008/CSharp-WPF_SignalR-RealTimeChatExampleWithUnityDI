using SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow.MethodParameters.WindowShowOptions.Interfaces;
using SullyTech.Wpf.Windows.Navigation.ViewModels.Initializers.NavigationWindow.Models.Interfaces;
using SullyTech.Wpf.Windows.Navigation.ViewModels.Initializers.NavigationWindowSettings.Models.Interfaces;
using SullyTech.Wpf.Windows.Navigation.ViewModels.Interfaces.NavigationWindow;
using SullyTech.Wpf.Windows.Navigation.ViewModels.Interfaces.NavigationWindowSettings;
using SullyTech.Wpf.Windows.Navigation.Window.Interfaces;

namespace SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow.MethodParameters.WindowShowOptions;

public sealed class NavigationWindowShowOptions<TINavigationWindow, TINavigationWindowViewModel, TINavigationWindowSettingsViewModel> : INavigationWindowShowOptions
    where TINavigationWindow : INavigationWindow
    where TINavigationWindowViewModel : INavigationWindowViewModel
    where TINavigationWindowSettingsViewModel : INavigationWindowSettingsViewModel
{
    Type INavigationWindowShowOptions.WindowType => typeof(TINavigationWindow);

    Type INavigationWindowShowOptions.WindowViewModelType => typeof(TINavigationWindowViewModel);

    Type INavigationWindowShowOptions.WindowSettingsViewModelType => typeof(TINavigationWindowSettingsViewModel);

    Type? INavigationWindowShowOptions.WindowViewModelInitializerModelType => 
        WindowViewModelInitializerModel?.GetType()
                                        .GetInterfaces()
                                        .Single(x => !x.IsClass &&
                                                     x.IsInterface &&
                                                     x.IsAssignableTo(typeof(INavigationWindowViewModelInitializerModel)) &&
                                                     x != typeof(INavigationWindowViewModelInitializerModel));

    Type? INavigationWindowShowOptions.WindowSettingsViewModelInitializerModelType =>
        WindowSettingsViewModelInitializerModel?.GetType()
                                                .GetInterfaces()
                                                .Single(x => !x.IsClass &&
                                                             x.IsInterface &&
                                                             x.IsAssignableTo(typeof(INavigationWindowSettingsViewModelInitializerModel)) &&
                                                             x != typeof(INavigationWindowSettingsViewModelInitializerModel));

    INavigationWindowViewModelInitializerModel? INavigationWindowShowOptions.WindowViewModelInitializerModel => WindowViewModelInitializerModel;

    INavigationWindowSettingsViewModelInitializerModel? INavigationWindowShowOptions.WindowSettingsViewModelInitializerModel => WindowSettingsViewModelInitializerModel;

    public INavigationWindowViewModelInitializerModel? WindowViewModelInitializerModel { get; init; }

    public INavigationWindowSettingsViewModelInitializerModel? WindowSettingsViewModelInitializerModel { get; init; }
}