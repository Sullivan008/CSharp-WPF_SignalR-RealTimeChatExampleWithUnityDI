using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Interfaces.PresenterData;

public interface IMessageDialogPresenterDataViewModel : IPresenterDataViewModel
{
    public string Message { get; set; }
}