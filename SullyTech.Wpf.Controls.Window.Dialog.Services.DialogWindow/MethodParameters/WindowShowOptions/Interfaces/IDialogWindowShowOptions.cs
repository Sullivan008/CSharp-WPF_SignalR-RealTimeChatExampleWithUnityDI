using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Initializer.Models.Interfaces.Window;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Initializer.Models.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Controls.Window.Dialog.Services.DialogWindow.MethodParameters.WindowShowOptions.Interfaces;

public interface IDialogWindowShowOptions
{
    internal Type WindowType { get; }

    internal Type WindowViewModelType { get; }

    internal Type WindowSettingsViewModelType { get; }

    internal Type? WindowViewModelInitializerModelType { get; }

    internal Type? WindowSettingsViewModelInitializerModelType { get; }

    internal IDialogWindowViewModelInitializerModel? WindowViewModelInitializerModel { get; }

    internal IDialogWindowSettingsViewModelInitializerModel? WindowSettingsViewModelInitializerModel { get; }
}