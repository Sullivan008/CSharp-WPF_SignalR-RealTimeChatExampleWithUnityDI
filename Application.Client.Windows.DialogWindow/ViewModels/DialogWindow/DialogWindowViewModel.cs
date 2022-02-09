using Application.Client.Windows.Core.ViewModels.Window;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Interfaces;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindowSettings.Interfaces;

namespace Application.Client.Windows.DialogWindow.ViewModels.DialogWindow;

public class DialogWindowViewModel<TDialogWindowSettingsViewModel> : WindowViewModel<TDialogWindowSettingsViewModel>, IDialogWindowViewModel
    where TDialogWindowSettingsViewModel : IDialogWindowSettingsViewModel, new()
{ }