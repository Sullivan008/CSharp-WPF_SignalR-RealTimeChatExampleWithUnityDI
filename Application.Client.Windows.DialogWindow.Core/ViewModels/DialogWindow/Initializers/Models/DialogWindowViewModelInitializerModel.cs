using Application.Client.Windows.Core.ViewModels.Window.Initializer.Models;
using Application.Client.Windows.DialogWindow.Core.ViewModels.DialogWindow.Initializers.Models.Interfaces;
using Application.Client.Windows.DialogWindow.Core.ViewModels.DialogWindowSettings.Initializers.Models.Interfaces;

namespace Application.Client.Windows.DialogWindow.Core.ViewModels.DialogWindow.Initializers.Models;

public class DialogWindowViewModelInitializerModel<TDialogWindowSettingsViewModelInitializerModel> :
    WindowViewModelInitializerModel<TDialogWindowSettingsViewModelInitializerModel>, IDialogWindowViewModelInitializerModel
        where TDialogWindowSettingsViewModelInitializerModel : IDialogWindowSettingsViewModelInitializerModel
{ }