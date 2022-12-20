using System.Windows.Input;
using SullyTech.Wpf.Dialogs.MessageDialog.Presenter.ViewModels.Enums.Presenter;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Interfaces.Presenter;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Presenter.ViewModels.Interfaces.Presenter;

public interface IMessageDialogViewModel : IPresenterViewModel
{
    public IconType IconType { get; set; }

    public ButtonType ButtonType { get; set; }

    public ICommand OkCommand { get; }

    public ICommand NoCommand { get; }

    public ICommand YesCommand { get; }

    public ICommand CancelCommand { get; }
}