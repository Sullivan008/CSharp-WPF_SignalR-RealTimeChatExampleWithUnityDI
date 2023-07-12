using System.Windows.Input;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Enums.Presenter;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Interfaces.Presenter;

public interface IMessageDialogPresenterViewModel : IPresenterViewModel
{
    public new IMessageDialogPresenterDataViewModel Data { get; }

    public IconType IconType { get; set; }

    public ButtonType ButtonType { get; set; }

    public ICommand OkCommand { get; }

    public ICommand NoCommand { get; }

    public ICommand YesCommand { get; }

    public ICommand CancelCommand { get; }
}