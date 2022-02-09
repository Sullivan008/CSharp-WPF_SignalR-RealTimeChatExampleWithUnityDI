using Application.Client.Windows.Core.ViewModels.Window.Initializer.Interfaces;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Initializers.Models.Interfaces;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Interfaces;

namespace Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Initializers.Interfaces;

public interface IDialogWindowViewModelInitializer<in TDialogWindowViewModel, in TDialogWindowViewModelInitializerModel> :
    IWindowViewModelInitializer<TDialogWindowViewModel, TDialogWindowViewModelInitializerModel>
        where TDialogWindowViewModel : IDialogWindowViewModel
        where TDialogWindowViewModelInitializerModel : IDialogWindowViewModelInitializerModel
{ }