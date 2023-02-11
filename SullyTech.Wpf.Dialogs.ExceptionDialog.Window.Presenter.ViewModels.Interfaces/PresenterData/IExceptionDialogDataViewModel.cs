using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Presenter.ViewModels.Interfaces.PresenterData;

public interface IExceptionDialogDataViewModel : IPresenterDataViewModel
{
    public string Message { get; set; }

    public string Type { get; set; }

    public string StackTrace { get; set; }

    public string InnerException { get; set; }
}