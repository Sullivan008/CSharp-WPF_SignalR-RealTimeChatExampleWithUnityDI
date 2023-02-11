using System.Windows.Input;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Interfaces.Presenter;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Presenter.ViewModels.Interfaces.Presenter;

public interface IExceptionDialogViewModel : IPresenterViewModel
{
    public new IExceptionDialogDataViewModel Data { get; }

    public bool IsDeveloperMode { get; }

    public ICommand OkCommand { get; }
}