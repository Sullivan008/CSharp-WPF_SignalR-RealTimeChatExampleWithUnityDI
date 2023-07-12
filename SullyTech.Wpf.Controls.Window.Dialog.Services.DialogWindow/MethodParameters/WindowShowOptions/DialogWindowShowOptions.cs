using SullyTech.Wpf.Controls.Window.Dialog.Interfaces;
using SullyTech.Wpf.Controls.Window.Dialog.Services.DialogWindow.MethodParameters.WindowShowOptions.Interfaces;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Initializers.Window.Models.Interfaces;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Initializers.WindowSettings.Models.Interfaces;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Controls.Window.Dialog.Services.DialogWindow.MethodParameters.WindowShowOptions;

public class DialogWindowShowOptions<TIDialogWindow, TIDialogWindowViewModel, TIDialogWindowSettingsViewModel> : IDialogWindowShowOptions
    where TIDialogWindow : IDialogWindow
    where TIDialogWindowViewModel : IDialogWindowViewModel
    where TIDialogWindowSettingsViewModel : IDialogWindowSettingsViewModel
{
    Type IDialogWindowShowOptions.WindowType => typeof(TIDialogWindow);

    Type IDialogWindowShowOptions.WindowViewModelType => typeof(TIDialogWindowViewModel);

    Type IDialogWindowShowOptions.WindowSettingsViewModelType => typeof(TIDialogWindowSettingsViewModel);

    Type? IDialogWindowShowOptions.WindowViewModelInitializerModelType =>
        WindowViewModelInitializerModel?.GetType()
            .GetInterfaces()
            .Single(x => !x.IsClass &&
                         x.IsInterface &&
                         x.IsAssignableTo(typeof(IDialogWindowViewModelInitializerModel)) &&
                         x != typeof(IDialogWindowViewModelInitializerModel));

    Type? IDialogWindowShowOptions.WindowSettingsViewModelInitializerModelType =>
        WindowSettingsViewModelInitializerModel?.GetType()
            .GetInterfaces()
            .Single(x => !x.IsClass &&
                         x.IsInterface &&
                         x.IsAssignableTo(typeof(IDialogWindowSettingsViewModelInitializerModel)) &&
                         x != typeof(IDialogWindowSettingsViewModelInitializerModel));

    IDialogWindowViewModelInitializerModel? IDialogWindowShowOptions.WindowViewModelInitializerModel => WindowViewModelInitializerModel;

    IDialogWindowSettingsViewModelInitializerModel? IDialogWindowShowOptions.WindowSettingsViewModelInitializerModel => WindowSettingsViewModelInitializerModel;

    public IDialogWindowViewModelInitializerModel? WindowViewModelInitializerModel { get; init; }

    public IDialogWindowSettingsViewModelInitializerModel? WindowSettingsViewModelInitializerModel { get; init; }
}