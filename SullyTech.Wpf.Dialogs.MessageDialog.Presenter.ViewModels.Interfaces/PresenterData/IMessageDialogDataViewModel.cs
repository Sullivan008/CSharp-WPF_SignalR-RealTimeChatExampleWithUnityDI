using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Presenter.ViewModels.Interfaces.PresenterData;

public interface IMessageDialogDataViewModel : IPresenterDataViewModel
{
    public string Message { get; set; }
}