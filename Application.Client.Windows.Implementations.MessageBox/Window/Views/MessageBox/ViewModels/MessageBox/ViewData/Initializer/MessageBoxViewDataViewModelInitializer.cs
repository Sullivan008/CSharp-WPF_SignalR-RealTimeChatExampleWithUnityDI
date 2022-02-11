using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Initializers.Interfaces;
using Application.Client.Windows.Implementations.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.ViewData.Initializer.Models;

namespace Application.Client.Windows.Implementations.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.ViewData.Initializer;

public class MessageBoxViewDataViewModelInitializer : IContentPresenterViewDataViewModelInitializer<MessageBoxViewDataViewModel, MessageBoxViewDataViewModelInitializerModel>
{
    public void Initialize(MessageBoxViewDataViewModel contentPresenterViewDataViewModel, MessageBoxViewDataViewModelInitializerModel contentPresenterViewDataViewModelInitializerModel)
    {
        contentPresenterViewDataViewModel.Message = contentPresenterViewDataViewModelInitializerModel.Message;
    }
}