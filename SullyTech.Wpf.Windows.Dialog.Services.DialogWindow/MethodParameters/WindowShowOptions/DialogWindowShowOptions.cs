using SullyTech.Wpf.Windows.Dialog.Services.DialogWindow.MethodParameters.WindowShowOptions.Interfaces;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindow.Models.Interfaces;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindowSettings.Models.Interfaces;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Interfaces.DialogWindow;
using SullyTech.Wpf.Windows.Dialog.Window.Interfaces;

namespace SullyTech.Wpf.Windows.Dialog.Services.DialogWindow.MethodParameters.WindowShowOptions;

public class DialogWindowShowOptions<TDialogWindow, TDialogWindowViewModel> : IDialogWindowShowOptions
    where TDialogWindow : IDialogWindow
    where TDialogWindowViewModel : IDialogWindowViewModel
{
    Type IDialogWindowShowOptions.WindowType => typeof(TDialogWindow);

    Type IDialogWindowShowOptions.WindowViewModelType => typeof(TDialogWindowViewModel);

    IDialogWindowViewModelInitializerModel IDialogWindowShowOptions.WindowViewModelInitializerModel => WindowViewModelInitializerModel;

    IDialogWindowSettingsViewModelInitializerModel? IDialogWindowShowOptions.WindowSettingsViewModelInitializerModel => WindowSettingsViewModelInitializerModel;

    public IDialogWindowViewModelInitializerModel? WindowViewModelInitializerModel { get; init; }

    public IDialogWindowSettingsViewModelInitializerModel? WindowSettingsViewModelInitializerModel { get; init; }
}