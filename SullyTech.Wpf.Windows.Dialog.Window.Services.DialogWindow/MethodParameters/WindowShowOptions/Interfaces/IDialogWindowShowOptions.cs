using SullyTech.Wpf.Windows.Dialog.Window.ViewModels.Initializers.DialogWindow.Models.Interfaces;
using SullyTech.Wpf.Windows.Dialog.Window.ViewModels.Initializers.DialogWindowSettings.Models.Interfaces;

namespace SullyTech.Wpf.Windows.Dialog.Window.Services.DialogWindow.MethodParameters.WindowShowOptions.Interfaces;

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