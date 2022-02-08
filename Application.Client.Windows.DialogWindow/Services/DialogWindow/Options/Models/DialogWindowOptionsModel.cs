using Application.Client.Windows.ApplicationWindow.Services.ApplicationWindow.Options.Models;
using Application.Client.Windows.DialogWindow.Services.DialogWindow.Options.Models.Interfaces;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Initializers.Models.Interfaces;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Interfaces;
using Application.Client.Windows.DialogWindow.Window.Interfaces;

namespace Application.Client.Windows.DialogWindow.Services.DialogWindow.Options.Models;

public class DialogWindowOptionsModel<TDialogWindow, TDialogWindowViewModel, TDialogWindowViewModelInitializerModel> : 
                ApplicationWindowShowOptionsModel<TDialogWindow, TDialogWindowViewModel, TDialogWindowViewModelInitializerModel>, IDialogWindowOptionsModel
                    where TDialogWindow : IDialogWindow
                    where TDialogWindowViewModel : IDialogWindowViewModel
                    where TDialogWindowViewModelInitializerModel : IDialogWindowViewModelInitializerModel
{ }