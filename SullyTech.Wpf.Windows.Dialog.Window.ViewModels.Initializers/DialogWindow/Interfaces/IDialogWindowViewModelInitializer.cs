using SullyTech.Wpf.Windows.Core.Window.ViewModels.Initializers.Window.Interfaces;
using SullyTech.Wpf.Windows.Dialog.Window.ViewModels.Initializers.DialogWindow.Models.Interfaces;
using SullyTech.Wpf.Windows.Dialog.Window.ViewModels.Interfaces.DialogWindow;

namespace SullyTech.Wpf.Windows.Dialog.Window.ViewModels.Initializers.DialogWindow.Interfaces;

public interface IDialogWindowViewModelInitializer<in TIDialogWindowViewModel, in TIDialogWindowViewModelInitializerModel> :
    IWindowViewModelInitializer<TIDialogWindowViewModel, TIDialogWindowViewModelInitializerModel>
        where TIDialogWindowViewModel : IDialogWindowViewModel
        where TIDialogWindowViewModelInitializerModel : IDialogWindowViewModelInitializerModel
{ }