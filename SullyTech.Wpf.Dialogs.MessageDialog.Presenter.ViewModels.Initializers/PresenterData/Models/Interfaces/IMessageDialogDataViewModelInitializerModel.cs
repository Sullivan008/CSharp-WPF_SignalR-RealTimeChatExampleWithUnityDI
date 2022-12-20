using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;

internal interface IMessageDialogDataViewModelInitializerModel : IPresenterDataViewModelInitializerModel
{
    public string Message { get; init; }
}