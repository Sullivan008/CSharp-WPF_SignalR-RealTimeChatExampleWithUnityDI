using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializer.Models.Interfaces.PresenterData;

namespace SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Initializer.Models.Interfaces.PresenterData;

public interface IMessageDialogPresenterDataViewModelInitializerModel : IPresenterDataViewModelInitializerModel
{
    public string Message { get; init; }
}