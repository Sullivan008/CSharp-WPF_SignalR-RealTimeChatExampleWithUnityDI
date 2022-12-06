using SullyTech.Wpf.Dialogs.MessageDialog.Presenter.Views.MessageDialog.ViewModels.PresenterData.Initializer.Models;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.PresenterData.Interfaces;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Presenter.Views.MessageDialog.ViewModels.PresenterData.Initializer;

internal sealed class MessageDialogDataViewModelInitializer : IPresenterDataViewModelInitializer<MessageDialogDataViewModel, MessageDialogDataViewModelInitializerModel>
{
    public void Initialize(MessageDialogDataViewModel presenterDataViewModel, MessageDialogDataViewModelInitializerModel presenterDataViewModelInitializerModel)
    {
        presenterDataViewModel.Message = presenterDataViewModelInitializerModel.Message;
    }
}