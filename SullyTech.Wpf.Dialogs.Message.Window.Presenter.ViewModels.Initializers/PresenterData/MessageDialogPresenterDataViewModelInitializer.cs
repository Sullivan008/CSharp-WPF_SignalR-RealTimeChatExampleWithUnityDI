using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializers.PresenterData.Interfaces;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Initializers.PresenterData;

internal sealed class MessageDialogPresenterDataViewModelInitializer : IPresenterDataViewModelInitializer<IMessageDialogPresenterDataViewModel, IMessageDialogPresenterDataViewModelInitializerModel>
{
    public void Initialize(IMessageDialogPresenterDataViewModel presenterDataViewModel, IMessageDialogPresenterDataViewModelInitializerModel presenterDataViewModelInitializerModel)
    {
        presenterDataViewModel.Message = presenterDataViewModelInitializerModel.Message;
    }
}