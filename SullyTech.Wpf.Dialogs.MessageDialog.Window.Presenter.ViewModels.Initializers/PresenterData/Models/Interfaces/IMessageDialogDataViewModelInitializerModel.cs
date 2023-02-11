using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;

public interface IMessageDialogDataViewModelInitializerModel : IPresenterDataViewModelInitializerModel
{
    public string Message { get; init; }
}