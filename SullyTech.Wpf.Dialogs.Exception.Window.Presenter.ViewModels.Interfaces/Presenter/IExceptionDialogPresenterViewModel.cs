using System.Windows.Input;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Interfaces.Presenter;

public interface IExceptionDialogPresenterViewModel : IPresenterViewModel
{
    public new IExceptionDialogPresenterDataViewModel Data { get; }

    public bool IsDeveloperMode { get; }

    public ICommand OkCommand { get; }
}