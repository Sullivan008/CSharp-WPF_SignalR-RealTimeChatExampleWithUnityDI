using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Presenter.ViewModels.Interfaces.PresenterData;

public interface IExceptionDialogDataViewModel : IPresenterDataViewModel
{
    public string Message { get; set; }

    public string Type { get; set; }

    public string StackTrace { get; set; }

    public string InnerException { get; set; }
}