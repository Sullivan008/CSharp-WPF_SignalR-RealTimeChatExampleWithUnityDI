using SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindow.Models.Interfaces;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindowSettings.Models.Interfaces;

namespace SullyTech.Wpf.Windows.Dialog.Services.DialogWindow.MethodParameters.WindowShowOptions.Interfaces;

public interface IDialogWindowShowOptions
{
    internal Type WindowType { get; }

    internal Type WindowViewModelType { get; }

    internal IDialogWindowViewModelInitializerModel? WindowViewModelInitializerModel { get; }

    internal IDialogWindowSettingsViewModelInitializerModel? WindowSettingsViewModelInitializerModel { get; }
}