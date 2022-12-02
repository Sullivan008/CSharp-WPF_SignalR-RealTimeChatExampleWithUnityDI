using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.Enums;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.Initializer.Models;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.Presenter.Interfaces;

namespace Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.Initializer;

public class MessageBoxViewModelInitializer : IPresenterViewModelInitializer<MessageBoxViewModel, MessageBoxViewModelInitializerModel>
{
    public MessageBoxViewModelInitializer()
    { }

    public void Initialize(MessageBoxViewModel contentPresenterViewModel, MessageBoxViewModelInitializerModel contentPresenterViewModelInitializerModel)
    {
        contentPresenterViewModel.MessageBoxButton = (MessageBoxButton)contentPresenterViewModelInitializerModel.MessageBoxButton;
        contentPresenterViewModel.MessageBoxIcon = InitializeMessageBoxIcon(contentPresenterViewModelInitializerModel.MessageBoxIcon);
    }

    private static MessageBoxIcon InitializeMessageBoxIcon(Models.Enums.MessageBoxIcon? messageBoxIcon)
    {
        return messageBoxIcon.HasValue == false ? MessageBoxIcon.None : (MessageBoxIcon)messageBoxIcon.Value;
    }
}