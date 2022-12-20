using SullyTech.Wpf.Windows.Core.ViewModels.Initializers.Window.Interfaces;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindow.Models.Interfaces;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Interfaces.DialogWindow;

namespace SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindow.Interfaces;

public interface IDialogWindowViewModelInitializer<in TIDialogWindowViewModel, in TIDialogWindowViewModelInitializerModel> :
    IWindowViewModelInitializer<TIDialogWindowViewModel, TIDialogWindowViewModelInitializerModel>
        where TIDialogWindowViewModel : IDialogWindowViewModel
        where TIDialogWindowViewModelInitializerModel : IDialogWindowViewModelInitializerModel
{ }