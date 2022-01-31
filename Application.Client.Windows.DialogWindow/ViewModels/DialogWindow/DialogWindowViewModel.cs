using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Interfaces;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindowSettings.Interfaces;

namespace Application.Client.Windows.DialogWindow.ViewModels.DialogWindow;

public class DialogWindowViewModel<TDialogWindowSettingsViewModel> : ApplicationWindowViewModel<TDialogWindowSettingsViewModel>, IDialogWindowViewModel
    where TDialogWindowSettingsViewModel : IDialogWindowSettingsViewModel, new()
{ }