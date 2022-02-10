using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Initializers.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Initializers.Interfaces;
using Application.Client.Windows.Implementations.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.Enums;
using Application.Client.Windows.Implementations.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.Initializer.Models;
using Application.Client.Windows.Implementations.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.ViewData;
using Application.Client.Windows.Implementations.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.ViewData.Initializer.Models;

namespace Application.Client.Windows.Implementations.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.Initializer;

public class MessageBoxViewModelInitializer : IContentPresenterViewModelInitializer<MessageBoxViewModel, MessageBoxViewModelInitializerModel>
{
    private readonly IContentPresenterViewDataViewModelInitializer<MessageBoxViewDataViewModel, MessageBoxViewDataViewModelInitializerModel> _viewDataInitializer;

    public MessageBoxViewModelInitializer(IContentPresenterViewDataViewModelInitializer<MessageBoxViewDataViewModel, MessageBoxViewDataViewModelInitializerModel> viewDataInitializer)
    {
        _viewDataInitializer = viewDataInitializer;
    }

    public void Initialize(MessageBoxViewModel contentPresenterViewModel, MessageBoxViewModelInitializerModel contentPresenterViewModelInitializerModel)
    {
        _viewDataInitializer.Initialize(contentPresenterViewModel.ViewData, contentPresenterViewModelInitializerModel.ViewDataInitializerModel);

        contentPresenterViewModel.MessageBoxButton = (MessageBoxButton)contentPresenterViewModelInitializerModel.MessageBoxButton;

    }
}