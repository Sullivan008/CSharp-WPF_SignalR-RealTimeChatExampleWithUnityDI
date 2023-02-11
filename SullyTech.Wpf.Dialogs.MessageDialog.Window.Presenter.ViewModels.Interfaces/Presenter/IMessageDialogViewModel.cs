using System.Windows.Input;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Enums.Presenter;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Interfaces.Presenter;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Interfaces.Presenter;

public interface IMessageDialogViewModel : IPresenterViewModel
{
    public new IMessageDialogDataViewModel Data { get; }

    public IconType IconType { get; set; }

    public ButtonType ButtonType { get; set; }

    public ICommand OkCommand { get; }

    public ICommand NoCommand { get; }

    public ICommand YesCommand { get; }

    public ICommand CancelCommand { get; }
}