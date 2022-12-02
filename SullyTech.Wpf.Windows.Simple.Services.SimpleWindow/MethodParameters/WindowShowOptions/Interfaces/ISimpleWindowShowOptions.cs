using SullyTech.Wpf.Windows.Simple.ViewModels.Initializers.SimpleWindow.Models.Interfaces;
using SullyTech.Wpf.Windows.Simple.ViewModels.Initializers.SimpleWindowSettings.Models.Interfaces;

namespace SullyTech.Wpf.Windows.Simple.Services.SimpleWindow.MethodParameters.WindowShowOptions.Interfaces;

public interface ISimpleWindowShowOptions
{
    internal Type WindowType { get; }

    internal Type WindowViewModelType { get; }

    internal ISimpleWindowViewModelInitializerModel? WindowViewModelInitializerModel { get; }

    internal ISimpleWindowSettingsViewModelInitializerModel? WindowSettingsViewModelInitializerModel { get; }
}