using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindowSettings.Interfaces;

namespace Application.Client.Windows.DialogWindow.ViewModels.DialogWindow;

public class DialogWindowViewModel<TDalogWindowSettingsViewModel> : ApplicationWindowViewModel<TDalogWindowSettingsViewModel>, IDialogWindowSettingsViewModel
where TDalogWindowSettingsViewModel : IDialogWindowSettingsViewModel, new()
{
}