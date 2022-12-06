using SullyTech.Wpf.Dialogs.MessageDialog.Presenter.Views.MessageDialog.ViewModels.Presenter.Initializer.Models;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.Presenter.Interfaces;
using ButtonType = SullyTech.Wpf.Dialogs.MessageDialog.Presenter.Views.MessageDialog.ViewModels.Presenter.Enums.ButtonType;
using IconType = SullyTech.Wpf.Dialogs.MessageDialog.Presenter.Views.MessageDialog.ViewModels.Presenter.Enums.IconType;
using InitializerIconType = SullyTech.Wpf.Dialogs.MessageDialog.Presenter.Views.MessageDialog.ViewModels.Presenter.Initializer.Models.Enums.IconType;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Presenter.Views.MessageDialog.ViewModels.Presenter.Initializer;

internal sealed class MessageBoxViewModelInitializer : IPresenterViewModelInitializer<MessageDialogViewModel, MessageDialogViewModelInitializerModel>
{
    public void Initialize(MessageDialogViewModel presenterViewModel, MessageDialogViewModelInitializerModel presenterViewModelInitializerModel)
    {
        presenterViewModel.ButtonType = (ButtonType)presenterViewModelInitializerModel.ButtonType;
        presenterViewModel.IconType = InitializeIconType(presenterViewModelInitializerModel.IconType);
    }

    private static IconType InitializeIconType(InitializerIconType? iconType)
    {
        return iconType.HasValue == false ? IconType.None : (IconType)iconType.Value;
    }
}