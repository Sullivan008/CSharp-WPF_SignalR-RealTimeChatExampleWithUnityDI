using SullyTech.Wpf.Controls.Window.Standard.Interfaces;
using SullyTech.Wpf.Controls.Window.Standard.Services.StandardWindow.MethodParameters.WindowShowOptions.Interfaces;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Initializers.Window.Models.Interfaces;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Initializers.WindowSettings.Models.Interfaces;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Controls.Window.Standard.Services.StandardWindow.MethodParameters.WindowShowOptions;

public sealed class StandardWindowShowOptions<TIStandardWindow, TIStandardWindowViewModel, TIStandardWindowSettingsViewModel> : IStandardWindowShowOptions
    where TIStandardWindow : IStandardWindow
    where TIStandardWindowViewModel : IStandardWindowViewModel
    where TIStandardWindowSettingsViewModel : IStandardWindowSettingsViewModel
{
    Type IStandardWindowShowOptions.WindowType => typeof(TIStandardWindow);

    Type IStandardWindowShowOptions.WindowViewModelType => typeof(TIStandardWindowViewModel);

    Type IStandardWindowShowOptions.WindowSettingsViewModelType => typeof(TIStandardWindowSettingsViewModel);

    Type? IStandardWindowShowOptions.WindowViewModelInitializerModelType =>
        WindowViewModelInitializerModel?.GetType()
                                        .GetInterfaces()
                                        .Single(x => !x.IsClass &&
                                                     x.IsInterface &&
                                                     x.IsAssignableTo(typeof(IStandardWindowViewModelInitializerModel)) &&
                                                     x != typeof(IStandardWindowViewModelInitializerModel));

    Type? IStandardWindowShowOptions.WindowSettingsViewModelInitializerModelType =>
        WindowSettingsViewModelInitializerModel?.GetType()
                                                .GetInterfaces()
                                                .Single(x => !x.IsClass &&
                                                             x.IsInterface &&
                                                             x.IsAssignableTo(typeof(IStandardWindowSettingsViewModelInitializerModel)) &&
                                                             x != typeof(IStandardWindowSettingsViewModelInitializerModel));

    IStandardWindowViewModelInitializerModel? IStandardWindowShowOptions.WindowViewModelInitializerModel => WindowViewModelInitializerModel;

    IStandardWindowSettingsViewModelInitializerModel? IStandardWindowShowOptions.WindowSettingsViewModelInitializerModel => WindowSettingsViewModelInitializerModel;

    public IStandardWindowViewModelInitializerModel? WindowViewModelInitializerModel { get; init; }

    public IStandardWindowSettingsViewModelInitializerModel? WindowSettingsViewModelInitializerModel { get; init; }
}