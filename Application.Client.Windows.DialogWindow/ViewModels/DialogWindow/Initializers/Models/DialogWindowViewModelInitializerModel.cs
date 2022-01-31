using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Initializers.Models;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Initializers.Models.Interfaces;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindowSettings.Initializers.Models.Interfaces;

namespace Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Initializers.Models;

public class DialogWindowViewModelInitializerModel<TDialogWindowSettingsViewModelInitializerModel> :
                ApplicationWindowViewModelInitializerModel<TDialogWindowSettingsViewModelInitializerModel>, IDialogWindowViewModelInitializerModel
                    where TDialogWindowSettingsViewModelInitializerModel : IDialogWindowSettingsViewModelInitializerModel
{ }