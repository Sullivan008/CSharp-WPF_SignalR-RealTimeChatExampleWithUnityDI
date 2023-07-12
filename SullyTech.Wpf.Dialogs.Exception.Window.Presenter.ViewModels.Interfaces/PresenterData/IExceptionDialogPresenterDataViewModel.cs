using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Interfaces.PresenterData;

public interface IExceptionDialogPresenterDataViewModel : IPresenterDataViewModel
{
    public string Message { get; set; }

    public string Type { get; set; }

    public string StackTrace { get; set; }

    public string InnerException { get; set; }
}