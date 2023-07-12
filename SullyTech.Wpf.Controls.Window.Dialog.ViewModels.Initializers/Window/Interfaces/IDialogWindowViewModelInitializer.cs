using SullyTech.Wpf.Controls.Window.Core.ViewModels.Initializers.Window.Interfaces;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Initializers.Window.Models.Interfaces;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Interfaces.Window;

namespace SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Initializers.Window.Interfaces;

public interface IDialogWindowViewModelInitializer<in TIDialogWindowViewModel, in TIDialogWindowViewModelInitializerModel> :
    IWindowViewModelInitializer<TIDialogWindowViewModel, TIDialogWindowViewModelInitializerModel>
        where TIDialogWindowViewModel : IDialogWindowViewModel
        where TIDialogWindowViewModelInitializerModel : IDialogWindowViewModelInitializerModel
{ }