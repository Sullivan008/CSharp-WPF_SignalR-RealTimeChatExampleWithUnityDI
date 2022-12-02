using SullyTech.Wpf.Windows.Simple.Services.SimpleWindow.MethodParameters.WindowShowOptions.Interfaces;
using SullyTech.Wpf.Windows.Simple.ViewModels.Initializers.SimpleWindow.Models.Interfaces;
using SullyTech.Wpf.Windows.Simple.ViewModels.Initializers.SimpleWindowSettings.Models.Interfaces;
using SullyTech.Wpf.Windows.Simple.ViewModels.Interfaces.SimpleWindow;
using SullyTech.Wpf.Windows.Simple.Window.Interfaces;

namespace SullyTech.Wpf.Windows.Simple.Services.SimpleWindow.MethodParameters.WindowShowOptions;

public sealed class SimpleWindowShowOptions<TSimpleWindow, TSimpleWindowViewModel> : ISimpleWindowShowOptions
    where TSimpleWindow : ISimpleWindow
    where TSimpleWindowViewModel : ISimpleWindowViewModel
{
    Type ISimpleWindowShowOptions.WindowType => typeof(TSimpleWindow);

    Type ISimpleWindowShowOptions.WindowViewModelType => typeof(TSimpleWindowViewModel);

    ISimpleWindowViewModelInitializerModel? ISimpleWindowShowOptions.WindowViewModelInitializerModel => WindowViewModelInitializerModel;

    ISimpleWindowSettingsViewModelInitializerModel? ISimpleWindowShowOptions.WindowSettingsViewModelInitializerModel => WindowSettingsViewModelInitializerModel;

    public ISimpleWindowViewModelInitializerModel? WindowViewModelInitializerModel { get; init; }

    public ISimpleWindowSettingsViewModelInitializerModel? WindowSettingsViewModelInitializerModel { get; init; }
}