using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;

namespace SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;

public interface IMessageDialogPresenterDataViewModelInitializerModel : IPresenterDataViewModelInitializerModel
{
    public string Message { get; init; }
}