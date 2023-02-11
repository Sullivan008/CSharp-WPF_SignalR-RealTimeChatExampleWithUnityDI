using SullyTech.Wpf.Windows.Simple.Window.ViewModels.Initializers.SimpleWindow.Models.Interfaces;
using SullyTech.Wpf.Windows.Simple.Window.ViewModels.Initializers.SimpleWindowSettings.Models.Interfaces;

namespace SullyTech.Wpf.Windows.Simple.Window.Services.SimpleWindow.MethodParameters.WindowShowOptions.Interfaces;

public interface ISimpleWindowShowOptions
{
    internal Type WindowType { get; }

    internal Type WindowViewModelType { get; }

    internal Type WindowSettingsViewModelType { get; }

    internal Type? WindowViewModelInitializerModelType { get; }

    internal Type? WindowSettingsViewModelInitializerModelType { get; }

    internal ISimpleWindowViewModelInitializerModel? WindowViewModelInitializerModel { get; }

    internal ISimpleWindowSettingsViewModelInitializerModel? WindowSettingsViewModelInitializerModel { get; }
}