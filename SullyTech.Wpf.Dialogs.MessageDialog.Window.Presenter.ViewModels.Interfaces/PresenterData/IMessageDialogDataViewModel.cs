using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Interfaces.PresenterData;

public interface IMessageDialogDataViewModel : IPresenterDataViewModel
{
    public string Message { get; set; }
}