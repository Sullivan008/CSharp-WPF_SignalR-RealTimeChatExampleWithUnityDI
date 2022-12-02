using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.ViewData.Initializer.Models;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.PresenterData.Interfaces;

namespace Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.ViewData.Initializer;

public class MessageBoxViewDataViewModelInitializer : IPresenterDataViewModelInitializer<MessageBoxViewDataViewModel, MessageBoxViewDataViewModelInitializerModel>
{
    public void Initialize(MessageBoxViewDataViewModel contentPresenterViewDataViewModel, MessageBoxViewDataViewModelInitializerModel contentPresenterViewDataViewModelInitializerModel)
    {
        contentPresenterViewDataViewModel.Message = contentPresenterViewDataViewModelInitializerModel.Message;
    }
}