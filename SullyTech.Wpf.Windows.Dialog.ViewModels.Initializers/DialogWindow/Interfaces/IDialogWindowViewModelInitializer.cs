using SullyTech.Wpf.Windows.Core.ViewModels.Initializers.Window.Interfaces;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindow.Models.Interfaces;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Interfaces.DialogWindow;

namespace SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindow.Interfaces;

public interface IDialogWindowViewModelInitializer<in TDialogWindowViewModel, in TDialogWindowViewModelInitializerModel> :
    IWindowViewModelInitializer<TDialogWindowViewModel, TDialogWindowViewModelInitializerModel>
        where TDialogWindowViewModel : IDialogWindowViewModel
        where TDialogWindowViewModelInitializerModel : IDialogWindowViewModelInitializerModel
{ }