using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Initializers.Window.Models.Interfaces;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Initializers.WindowSettings.Models.Interfaces;

namespace SullyTech.Wpf.Controls.Window.Standard.Services.StandardWindow.MethodParameters.WindowShowOptions.Interfaces;

public interface IStandardWindowShowOptions
{
    internal Type WindowType { get; }

    internal Type WindowViewModelType { get; }

    internal Type WindowSettingsViewModelType { get; }

    internal Type? WindowViewModelInitializerModelType { get; }

    internal Type? WindowSettingsViewModelInitializerModelType { get; }

    internal IStandardWindowViewModelInitializerModel? WindowViewModelInitializerModel { get; }

    internal IStandardWindowSettingsViewModelInitializerModel? WindowSettingsViewModelInitializerModel { get; }
}