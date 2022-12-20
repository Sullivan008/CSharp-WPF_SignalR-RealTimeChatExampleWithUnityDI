using SullyTech.Wpf.Dialogs.MessageDialog.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;
using SullyTech.Wpf.Dialogs.MessageDialog.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.PresenterData.Interfaces;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Presenter.ViewModels.Initializers.PresenterData;

internal sealed class MessageDialogDataViewModelInitializer : IPresenterDataViewModelInitializer<IMessageDialogDataViewModel, IMessageDialogDataViewModelInitializerModel>
{
    public void Initialize(IMessageDialogDataViewModel presenterDataViewModel, IMessageDialogDataViewModelInitializerModel presenterDataViewModelInitializerModel)
    {
        presenterDataViewModel.Message = presenterDataViewModelInitializerModel.Message;
    }
}